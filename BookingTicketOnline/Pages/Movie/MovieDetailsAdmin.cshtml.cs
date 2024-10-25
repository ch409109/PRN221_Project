using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Movie
{
    public class MovieDetailsAdminModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public MovieDetailsAdminModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public Models.Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies
                .Include(m => m.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
