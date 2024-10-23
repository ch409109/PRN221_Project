using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Foods
{
    public class EditFoodsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public FoodAndDrink food { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public EditFoodsModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            food = await _context.FoodAndDrinks.FindAsync(id);

            if (food == null)
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

            var foodToUpdate = await _context.FoodAndDrinks.FindAsync(food.Id);

            if (foodToUpdate == null)
            {
                return NotFound();
            }

            foodToUpdate.Name = food.Name;
            foodToUpdate.Price = food.Price;
            foodToUpdate.Quantity = food.Quantity;
            foodToUpdate.Status = food.Status;

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

                if (!string.IsNullOrEmpty(foodToUpdate.Image))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, "img", foodToUpdate.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                foodToUpdate.Image = fileName;
            }

            _context.Attach(foodToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            TempData["success"] = "Foods updated successfully";

            return RedirectToPage("./ManageFoods");
        }
    }
}
