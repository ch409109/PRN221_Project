using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Seat
{
    public class ManageSeatsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public ManageSeatsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Models.Seat Seat { get; set; } = new Models.Seat();
        [BindProperty]
        public List<Models.Row> Rows { get; set; } = new List<Models.Row>();

        public async Task OnGetAsync(int Id)
        {
            HttpContext.Session.SetInt32("RoomID",Id);
            Rows = await _context.Rows.Include(row => row.Seats).Where(row => row.RoomId == Id).ToListAsync();

        }
    }
}
