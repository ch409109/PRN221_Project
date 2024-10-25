using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Cinema
{
    public class ChangeStatusModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public ChangeStatusModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinemas.FirstOrDefaultAsync(m => m.Id == id);

            if (Cinema == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Cinema == null || Cinema.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var cinemaToUpdate = await _context.Cinemas.FindAsync(Cinema.Id);

                if (cinemaToUpdate != null)
                {
                    cinemaToUpdate.Status = cinemaToUpdate.Status == "Active" ? "Inactive" : "Active";
                    _context.Update(cinemaToUpdate);
                    await _context.SaveChangesAsync();

                    TempData["success"] = $"Cinema status has been changed to {cinemaToUpdate.Status} successfully";
                    return RedirectToPage("./CinemaDetails", new { id = Cinema.Id });
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while changing the cinema status. Please try again.";
                return Page();
            }
        }
    }
}
