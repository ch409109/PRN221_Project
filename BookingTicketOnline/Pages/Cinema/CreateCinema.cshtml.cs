using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.Cinema
{
    public class CreateCinemaModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public CreateCinemaModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Cinema cinema { get; set; }

        public IActionResult OnGet()
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "1")
            {
                return RedirectToPage("/AccessDenied");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            cinema.Status = "Active";

            _context.Cinemas.Add(cinema);
            await _context.SaveChangesAsync();
            TempData["success"] = "Cinema created successfully";

            return RedirectToPage("./ManageCinemas");
        }
    }
}
