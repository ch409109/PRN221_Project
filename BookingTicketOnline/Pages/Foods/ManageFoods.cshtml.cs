using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Foods
{
    public class ManageFoodsModel : PageModel
    {
        public List<FoodAndDrink> foods = new List<FoodAndDrink>();

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortOrder { get; set; }

        public string PriceSortParam => SortOrder == "price_desc" ? "price_asc" : "price_desc";

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
            IQueryable<Models.FoodAndDrink> foodsQuery = _context.FoodAndDrinks;

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                foodsQuery = foodsQuery.Where(c => c.Name.Contains(CurrentFilter));
            }

            foodsQuery = SortOrder switch
            {
                "price_desc" => foodsQuery.OrderByDescending(f => f.Price),
                "price_asc" => foodsQuery.OrderBy(f => f.Price),
                _ => foodsQuery.OrderBy(f => f.Name)
            };

            var totalItems = await foodsQuery.CountAsync();
            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            CurrentPage = pageNumber > TotalPages ? 1 : pageNumber;

            foods = await foodsQuery
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();
        }
    }
}
