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

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 50;
        public int TotalPages { get; set; }

        public async Task<ActionResult> OnGetAsync()
        {
			if (!User.Identity.IsAuthenticated)
			{
				var returnURl = Url.Page("/HomeOwner");
				return RedirectToPage("/Login", new { returnURl = returnURl });
			}
			int totalRooms = await _context.Rooms.CountAsync();
            TotalPages = (int)System.Math.Ceiling(totalRooms / (double)PageSize);

            Rooms = await _context.Rooms
                .Include(r => r.Cinema)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (int.TryParse(Request.Form["id"], out int id))
            {
                HttpContext.Session.SetInt32("RoomID", id);
                return RedirectToPage("/ManageShowTime/Showtimes");
            }

            return Page();
        }
    }
}
