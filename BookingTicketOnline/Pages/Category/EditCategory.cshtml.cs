using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Category
{
    public class EditCategoryModel : PageModel
    {
        [BindProperty]
        public MovieCategory category { get; set; }

        private readonly PRN221_FinalProjectContext _context;

        public EditCategoryModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(category).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            TempData["success"] = "Category updated successfully";
            return RedirectToPage("./ManageCategories");
        }
    }
}
