using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Category
{
    public class DeleteCategoryModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public DeleteCategoryModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieCategory category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            category = await _context.MovieCategories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (category == null || category.Id == 0)
            {
                return NotFound();
            }

            try
            {
                var categoryToDelete = await _context.MovieCategories.FirstOrDefaultAsync(c => c.Id == category.Id);
                if (categoryToDelete != null)
                {
                    var hasMovies = await _context.Movies
                        .AnyAsync(m => m.CategoryId == category.Id);

                    if (hasMovies)
                    {
                        category = categoryToDelete;

                        TempData["error"] = "Cannot delete category because it contains movies. Please remove or reassign the movies first.";

                        return Page();
                    }

                    _context.MovieCategories.Remove(categoryToDelete);
                    await _context.SaveChangesAsync();
                }
                TempData["success"] = "Category deleted successfully";

                return RedirectToPage("./ManageCategories");
            }
            catch (Exception ex)
            {
                category = await _context.MovieCategories.FirstOrDefaultAsync(c => c.Id == category.Id);

                TempData["error"] = "An error occurred while deleting the category. Please try again.";
                return Page();
            }
        }
    }
}