using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Foods
{
    public class DeleteFoodsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public DeleteFoodsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FoodAndDrink food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            food = await _context.FoodAndDrinks.FirstOrDefaultAsync(f => f.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (food == null || food.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var foodToDelete = await _context.FoodAndDrinks.FindAsync(food.Id);
                if (foodToDelete != null)
                {
                    // Check if category is in use
                    //var hasMovies = await _context.Movies
                    //    .AnyAsync(m => m.CategoryId == category.Id);

                    //if (hasMovies)
                    //{
                    //    ModelState.AddModelError(string.Empty,
                    //        "Cannot delete category because it contains movies. Please remove or reassign the movies first.");
                    //    return Page();
                    //}

                    _context.FoodAndDrinks.Remove(foodToDelete);
                    await _context.SaveChangesAsync();
                    TempData["success"] = "Foods deleted successfully";
                }

                return RedirectToPage("./ManageFoods");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                    "An error occurred while deleting the food. Please try again.");
                return Page();
            }
        }
    }
}
