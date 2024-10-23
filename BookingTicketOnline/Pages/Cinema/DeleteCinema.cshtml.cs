using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Cinema
{
    public class DeleteCinemaModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public DeleteCinemaModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Cinema cinema { get; set; }

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
            if (cinema == null || cinema.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var cinemaToDelete = await _context.Cinemas.FindAsync(cinema.Id);
                if (cinemaToDelete != null)
                {
                    _context.Cinemas.Remove(cinemaToDelete);
                    await _context.SaveChangesAsync();
                }
                TempData["success"] = "Cinema deleted successfully";

                return RedirectToPage("./ManageCinemas");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                    "An error occurred while deleting the cinema. Please try again.");
                return Page();
            }
        }
    }
}
