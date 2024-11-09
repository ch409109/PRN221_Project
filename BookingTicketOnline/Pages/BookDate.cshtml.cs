using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages
{
    public class BookDateModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public BookDateModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public List<ShowtimeViewModel> Showtimes { get; set; }
        public Models.Movie Movie { get; set; }
        public string SelectedCity { get; set; }
        public List<DateTime> WeekDates { get; set; }
        public DateTime SelectedDate { get; set; }

        public async Task<IActionResult> OnGetAsync(string city = "Hà Nội", DateTime? date = null)
        {
            var movieId = HttpContext.Session.GetInt32("MovieId");
            if (!movieId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            // Set selected city and date
            SelectedCity = city;
            SelectedDate = date ?? DateTime.Today;

            // Get week dates
            WeekDates = GetWeekDates(SelectedDate);

            Movie = await _context.Movies.FindAsync(movieId.Value);
            if (Movie == null)
            {
                return NotFound();
            }

            var showtimes = await _context.Showtimes
            .Include(s => s.Room)
                .ThenInclude(r => r.Cinema)
            .Where(s => s.MovieId == movieId &&
                       s.Date.Value.Date == SelectedDate.Date &&
                       s.Room.Cinema.City == SelectedCity &&
                       s.Room.Cinema.Status == "Active")
            .ToListAsync();

            Showtimes = showtimes
            .GroupBy(s => s.Room.Cinema)
            .Select(g => new ShowtimeViewModel
            {
                Cinema = g.Key,
                ShowtimeSlots = g.Select(s => new ShowtimeSlot
                {
                    ShowtimeId = s.Id,
                    StartTime = s.StartTime.Value,
                    EndTime = s.EndTime.Value,
                    RoomName = s.Room.Name
                }).OrderBy(s => s.StartTime).ToList()
            })
            .ToList();

            return Page();
        }

        private List<DateTime> GetWeekDates(DateTime selectedDate)
        {
            var dates = new List<DateTime>();
            var today = DateTime.Today;
            for (int i = 0; i < 7; i++)
            {
                dates.Add(today.AddDays(i));
            }
            return dates;
        }

        public IActionResult OnPostSelectShowtime(int showtimeId)
        {
            HttpContext.Session.SetInt32("ShowtimeId", showtimeId);
            return RedirectToPage("/Seat/BookSeat");
        }
    }
}
