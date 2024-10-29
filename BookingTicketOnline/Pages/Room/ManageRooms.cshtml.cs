using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Room
{
    public class ManageRoomsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        public ManageRoomsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Models.Room> Rooms { get; set; }
        public async Task OnGetAsync(int id)
        {
            IQueryable<Models.Room> query = _context.Rooms.Include(c => c.Cinema);
            Rooms = await query.Where(c => c.CinemaId == id).ToListAsync();
        }
    }
}
