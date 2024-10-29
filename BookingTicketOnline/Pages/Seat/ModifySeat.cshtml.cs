using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Seat
{
    public class ModifySeatModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        public ModifySeatModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public List<Models.Seat> Seats { get; set; }
        public List<Models.Row> Rows { get; set; }
        public async Task<IActionResult> OnGetAsync(string action)
        {
            var roomID = 1;
            Rows = await _context.Rows.Include(s => s.Seats).Where(row => row.RoomId == roomID).ToListAsync();
            Seats = await _context.Seats.Include(s => s.Row).Where(s => s.Row.RoomId == roomID).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSaveAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    Rows = await _context.Rows.ToListAsync();
            //    return Page();
            //}

            //if (Seat.Id > 0)
            //{
            //    _context.Seats.Update(Seat);
            //}
            //else
            //{
            //    _context.Seats.Add(Seat);
            //}

            //await _context.SaveChangesAsync();
            return RedirectToPage("/Seat/ManageSeats");
        }
    }
}

