using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Movie
{
    public class MovieDetailsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public Models.Movie? Movie { get; set; }

        public MovieDetailsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(int id)
        {
            Movie = await _context.Movies
            .Include(m => m.Category)
            .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
