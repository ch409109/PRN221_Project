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
            IQueryable<MovieCategory> categoriesQuery = _context.MovieCategories;

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                categoriesQuery = categoriesQuery.Where(c => c.Name.Contains(CurrentFilter));
            }

            var totalItems = await categoriesQuery.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            CurrentPage = pageNumber > TotalPages ? 1 : pageNumber;

            categories = await categoriesQuery
                .OrderBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
