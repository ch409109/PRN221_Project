using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingTicketOnline.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookingTicketOnline.Pages.Foods
{
    public class BookFoodsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public BookFoodsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public List<FoodAndDrink> FoodAndDrinks { get; set; }

        [BindProperty]
        public Dictionary<int, int> Quantities { get; set; } = new Dictionary<int, int>();

        public async Task<IActionResult> OnGetAsync()
        {
            FoodAndDrinks = await _context.FoodAndDrinks
                .Where(f => f.Status == "Active")
                .ToListAsync();

            var savedQuantities = HttpContext.Session.GetString("FoodQuantities");
            if (!string.IsNullOrEmpty(savedQuantities))
            {
                Quantities = JsonSerializer.Deserialize<Dictionary<int, int>>(savedQuantities);
            }

            return Page();
        }

        private decimal CalculateTotalAmount()
        {
            decimal total = 0;
            foreach (var quantity in Quantities.Where(q => q.Value > 0))
            {
                var food = FoodAndDrinks.FirstOrDefault(f => f.Id == quantity.Key);
                if (food != null)
                {
                    total += food.Price * quantity.Value;
                }
            }
            return total;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            HttpContext.Session.SetString("FoodQuantities",
                JsonSerializer.Serialize(Quantities));

            FoodAndDrinks = await _context.FoodAndDrinks
            .Where(f => f.Status == "Active")
            .ToListAsync();
            decimal totalAmount = CalculateTotalAmount();
            HttpContext.Session.SetString("FoodTotalAmount",
                JsonSerializer.Serialize(totalAmount));

            // Filter selected items (quantity > 0)
            var selectedItems = Quantities
                .Where(q => q.Value > 0)
                .Select(q => new
                {
                    FoodId = q.Key,
                    Quantity = q.Value
                })
                .ToList();

            if (selectedItems.Any())
            {
                HttpContext.Session.SetString("SelectedFoods",
                    JsonSerializer.Serialize(selectedItems));
            }
            else
            {
                // Xóa dữ liệu đồ ăn trong session nếu không chọn món nào
                HttpContext.Session.Remove("SelectedFoods");
                HttpContext.Session.Remove("FoodQuantities");
                HttpContext.Session.SetString("FoodTotalAmount",
                    JsonSerializer.Serialize(0m)); // Lưu tổng tiền = 0
            }

            // Save to session or database
            HttpContext.Session.SetString("SelectedFoods",
                JsonSerializer.Serialize(selectedItems));

            return RedirectToPage("/CheckOut");
        }
    }
}