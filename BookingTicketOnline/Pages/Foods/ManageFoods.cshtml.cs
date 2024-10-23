using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Foods
{
    public class ManageFoodsModel : PageModel
    {
        public List<FoodAndDrink> foodAndDrinks = new List<FoodAndDrink>();

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        private readonly PRN221_FinalProjectContext _context;

        public ManageFoodsModel(PRN221_FinalProjectContext context)
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

            IQueryable<FoodAndDrink> foodAndDrinksQuery = _context.FoodAndDrinks;

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                foodAndDrinksQuery = foodAndDrinksQuery.Where(f => f.Name.Contains(CurrentFilter));
            }

            foodAndDrinks = await foodAndDrinksQuery
                .OrderBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
