using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.Foods
{
    public class FoodsDetailsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public FoodsDetailsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public Models.FoodAndDrink Foods { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

            if (id == null)
            {
                return NotFound();
            }

            Foods = await _context.FoodAndDrinks.FirstOrDefaultAsync(f => f.Id == id);

            if (Foods == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
