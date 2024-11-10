using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Movie
{
    public class MovieDetails2Model : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public Models.Movie? Movie { get; set; }
        public List<Feedback> Feedbacks { get; set; } = new();
        public int TotalReviews { get; set; }
        public double AverageRating { get; set; }


        [BindProperty]
        public string CommentText { get; set; } = string.Empty;

        [BindProperty]
        public int Rate { get; set; }

        public bool CanComment { get; private set; } = false;


        public MovieDetails2Model(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id)
        {
            Movie = await _context.Movies
            .Include(m => m.Category)
            .FirstOrDefaultAsync(m => m.Id == id);

            Feedbacks = await _context.Feedbacks
                 .Where(f => f.MovieId == id)
                 .Include(f => f.User)
                 .OrderByDescending(f => f.CreateAt)
                 .ToListAsync();

            HttpContext.Session.SetInt32("MovieId", Movie.Id);

            if (Feedbacks.Any())
            {
                AverageRating = Feedbacks.Average(f => f.Rate ?? 0);
                TotalReviews = Feedbacks.Count;
            }

            var userIdClaim = User.FindFirst("UserId")?.Value;

            if (userIdClaim != null && int.TryParse(userIdClaim, out int userId))
            {
                CanComment = await _context.Bookings
                    .AnyAsync(b => b.UserId == userId
                    && b.Showtime.MovieId == id
                    && b.Status == "Confirmed");
            }
            else
            {
                CanComment = false;
            }
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var userIdClaim = User.FindFirst("UserId")?.Value;
            if (userIdClaim == null || !int.TryParse(userIdClaim, out int userId))
            {
                return RedirectToPage("/Login");
            }
            var newFeedback = new Feedback
            {
                MovieId = id,
                UserId = userId,
                Comments = CommentText,
                Rate = Rate,
                CreateAt = DateTime.Now
            };

            _context.Feedbacks.Add(newFeedback);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Movie/MovieDetails2", new { id = id });
        }

        public string GetEmbedUrl(string url)
        {
            if (string.IsNullOrEmpty(url))
                return "";

            // Xử lý URL dạng youtube.com/watch?v=
            if (url.Contains("watch?v="))
            {
                var videoId = url.Split("watch?v=")[1];
                return $"https://www.youtube.com/embed/{videoId}";
            }
            // Xử lý URL dạng youtu.be/
            else if (url.Contains("youtu.be/"))
            {
                var videoId = url.Split("youtu.be/")[1];
                return $"https://www.youtube.com/embed/{videoId}";
            }

            return url; // Trả về nguyên URL nếu không match các pattern trên
        }

    }
}
