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

        public MovieDetails2Model(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id)
        {
            Movie = await _context.Movies
            .Include(m => m.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
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
