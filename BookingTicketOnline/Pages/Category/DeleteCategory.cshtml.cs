using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "1")
            {
                return RedirectToPage("/AccessDenied");
            }

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

                        TempData["error"] = "Không thể xóa danh mục vì nó chứa phim. Vui lòng xóa hoặc gán lại cho phim trước.";

                        return Page();
                    }

                    _context.MovieCategories.Remove(categoryToDelete);
                    await _context.SaveChangesAsync();
                }
                TempData["success"] = "Xóa thể loại phim thành công";

                return RedirectToPage("./ManageCategories");
            }
            catch (Exception ex)
            {
                category = await _context.MovieCategories.FirstOrDefaultAsync(c => c.Id == category.Id);

                TempData["error"] = "Có lỗi xảy ra khi xóa. Vui lòng thử lại.";
                return Page();
            }
        }
    }
}