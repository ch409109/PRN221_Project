using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingTicketOnline.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class CreateModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public CreateModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Showtime Showtime { get; set; } = new Showtime();

        // Thêm các thuộc tính cho Movie, Cinema, và Room
        public SelectList MovieList { get; set; }
        public SelectList CinemaList { get; set; }
        public SelectList RoomList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách Movies, Cinemas và Rooms từ cơ sở dữ liệu
            MovieList = new SelectList(await _context.Movies.ToListAsync(), "Id", "Title");
            CinemaList = new SelectList(await _context.Cinemas.ToListAsync(), "Id", "Name");
            RoomList = new SelectList(await _context.Rooms.ToListAsync(), "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Showtimes.Add(Showtime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
