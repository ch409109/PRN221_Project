using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class ShowtimesModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        public ShowtimesModel (PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        public List<Models.Showtime> showtimes { get; set; }
        public async Task OnGetAsync()
        {
            showtimes = await _context.Showtimes
    .Include(s => s.Movie) // Lấy thông tin movie
    .Include(s => s.Room) // Lấy thông tin room
    .ToListAsync();
        }
    }
}
