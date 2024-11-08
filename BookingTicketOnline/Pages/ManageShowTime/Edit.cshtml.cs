using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class EditModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public EditModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        //    [BindProperty]
        //    public Showtime Showtime { get; set; } = default!;

        //    public List<SelectListItem> ExistingShowtimes { get; set; } = new List<SelectListItem>();

        //    public async Task<IActionResult> OnGetAsync(int? id)
        //    {
        //        // Populate the existing showtimes for the dropdown
        //        ExistingShowtimes = await _context.Showtimes
        //            .Select(s => new SelectListItem
        //            {
        //                Value = s.Id.ToString(),
        //                //Text = $"{s.Showtime1} - {s.Movie.Title} - Room {s.RoomId}"
        //            }).ToListAsync();

        //        if (id == null || _context.Showtimes == null)
        //        {
        //            return NotFound();
        //        }

        //        var showtime = await _context.Showtimes.Include(s => s.Movie).Include(s => s.Bookings).Include(s => s.Room).FirstOrDefaultAsync(m => m.Id == id);
        //        if (showtime == null)
        //        {
        //            return NotFound();
        //        }

        //        Showtime = showtime;
        //        ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "Name");
        //        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
        //        ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Name");

        //        return Page();
        //    }

        //    public async Task<IActionResult> OnPostAsync()
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return Page();
        //        }

        //        _context.Attach(Showtime).State = EntityState.Modified;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ShowtimeExists(Showtime.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }

        //        return RedirectToPage("./Index");
        //    }

        //    private bool ShowtimeExists(int id)
        //    {
        //        return (_context.Showtimes?.Any(e => e.Id == id)).GetValueOrDefault();
        //    }

        //    // New method to get showtime details
        //    public async Task<JsonResult> OnGetGetShowtimeDetails(int id)
        //    {
        //        var showtime = await _context.Showtimes
        //            .Where(s => s.Id == id)
        //            .Select(s => new
        //            {
        //                s.MovieId,
        //                //s.CinemaId,
        //                s.RoomId,
        //                //s.Showtime1,
        //                s.Date
        //            })
        //            .FirstOrDefaultAsync();

        //        return new JsonResult(showtime);
        //    }
    }
}
