using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Foods
{
    public class ChangeStatusModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public ChangeStatusModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.FoodAndDrink Foods { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (Foods == null || Foods.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var foodsToUpdate = await _context.FoodAndDrinks.FindAsync(Foods.Id);

                if (foodsToUpdate != null)
                {
                    foodsToUpdate.Status = foodsToUpdate.Status == "Active" ? "Inactive" : "Active";
                    _context.Update(foodsToUpdate);
                    await _context.SaveChangesAsync();

                    TempData["success"] = $"Foods status has been changed to {foodsToUpdate.Status} successfully";
                    return RedirectToPage("./FoodsDetails", new { id = Foods.Id });
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["error"] = "An error occurred while changing the foods status. Please try again.";
                return Page();
            }
        }
    }
}
