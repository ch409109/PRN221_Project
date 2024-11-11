using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookingTicketOnline.Pages.Room
{
    public class CreateRoomModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public CreateRoomModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Room Room { get; set; } = new Models.Room();

        public async Task<IActionResult> OnPostAsync()
        {
            var cinemaID = HttpContext.Session.GetInt32("CinemaID");

            _context.Rooms.Add(Room);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index"); // Chuyển hướng về trang danh sách phòng sau khi tạo
        }
    }
}
