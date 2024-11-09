using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.Foods
{
    public class CreateFoodsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateFoodsModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public FoodAndDrink food { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (ImageFile != null)
            {
                var originalFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var fileExtension = Path.GetExtension(ImageFile.FileName);
                var fileName = $"{Guid.NewGuid()}_{originalFileName}{fileExtension}";
                var filePath = Path.Combine(_environment.WebRootPath, "img", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                food.Image = fileName;
            }

            food.Status = "Active";

            _context.FoodAndDrinks.Add(food);
            await _context.SaveChangesAsync();
            TempData["success"] = "Foods created successfully";

            return RedirectToPage("./ManageFoods");
        }
    }
}
