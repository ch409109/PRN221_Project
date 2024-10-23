using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.Category
{
    public class CreateCategoryModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public CreateCategoryModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieCategory category { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieCategories.Add(category);
            await _context.SaveChangesAsync();
            TempData["success"] = "Category created successfully";

            return RedirectToPage("./ManageCategories");
        }
    }
}
