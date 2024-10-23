using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Category
{
    public class ManageCategoriesModel : PageModel
    {
        public List<Models.MovieCategory> categories = new List<Models.MovieCategory>();
        private readonly PRN221_FinalProjectContext _context;

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        public int PageSize { get; set; } = 5; 
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public ManageCategoriesModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString, int pageNumber = 1)
        {
            var totalItems = await _context.MovieCategories.CountAsync();

            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            CurrentPage = pageNumber;

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }

            IQueryable<MovieCategory> categoriesQuery = _context.MovieCategories;

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                categoriesQuery = categoriesQuery.Where(c =>
                    c.Name.Contains(CurrentFilter));
            }

            categories = await categoriesQuery
                .OrderBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize) // B? qua các m?c c?a các trang tr??c
                .Take(PageSize)                     // L?y s? m?c cho trang hi?n t?i
                .ToListAsync();
        }
    }
}
