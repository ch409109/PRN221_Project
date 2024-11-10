using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public IndexModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public List<Models.Room> Rooms { get; set; } = new List<Models.Room>();

        public async Task OnGetAsync()
        {
            Rooms = await _context.Rooms.Include(r => r.Cinema).ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var id = Int32.Parse(Request.Form["id"]);
            HttpContext.Session.SetInt32("RoomID", id);

            return RedirectToPage("/ManageShowTime/Showtimes");
        }
    }
}
