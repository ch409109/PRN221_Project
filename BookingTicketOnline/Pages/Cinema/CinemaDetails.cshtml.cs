using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Cinema
{
    public class CinemaDetailsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public CinemaDetailsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public Models.Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinemas.FirstOrDefaultAsync(c => c.Id == id);

            if (Cinema == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
