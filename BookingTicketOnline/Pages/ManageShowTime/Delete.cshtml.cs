using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class DeleteModel : PageModel
    {
        //private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        //public DeleteModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        //{
        //    _context = context;
        //}

        //[BindProperty]
        //public Showtime Showtime { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Showtimes == null)
        //    {
        //        return NotFound();
        //    }

        //    // Lấy thông tin Showtime và các thông tin liên quan
        //    Showtime = await _context.Showtimes
        //        .Include(s => s.Movie)
        //        //.Include(s => s.Cinema)
        //        .Include(s => s.Room)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (Showtime == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null || _context.Showtimes == null)
        //    {
        //        return NotFound();
        //    }

        //    // Lấy Showtime cần xóa
        //    var showtime = await _context.Showtimes.FindAsync(id);

        //    if (showtime != null)
        //    {
        //        Showtime = showtime;
        //        _context.Showtimes.Remove(Showtime);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
