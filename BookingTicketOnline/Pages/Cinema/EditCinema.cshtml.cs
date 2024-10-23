using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Cinema
{
    public class EditCinemaModel : PageModel
    {
        [BindProperty]
        public Models.Cinema cinema { get; set; }

        private readonly PRN221_FinalProjectContext _context;

        public EditCinemaModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            cinema = await _context.Cinemas.FirstOrDefaultAsync(m => m.Id == id);

            if (cinema == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(cinema).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            TempData["success"] = "Cinema updated successfully";
            return RedirectToPage("./ManageCinemas");
        }
    }
}
