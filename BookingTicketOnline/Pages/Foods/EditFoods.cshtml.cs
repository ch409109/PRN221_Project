using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.Foods
{
    public class EditFoodsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public FoodAndDrink food { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public EditFoodsModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

            food = await _context.FoodAndDrinks.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);

            if (food == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ImageFile == null)
            {
                ModelState.Remove("ImageFile");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var foodToUpdate = await _context.FoodAndDrinks.AsNoTracking().FirstOrDefaultAsync(f => f.Id == food.Id);

            if (foodToUpdate == null)
            {
                return NotFound();
            }

            food.Status = foodToUpdate.Status;
            food.Image = foodToUpdate.Image;

            foodToUpdate.Name = food.Name;
            foodToUpdate.Price = food.Price;
            foodToUpdate.Quantity = food.Quantity;
            foodToUpdate.Status = food.Status;

            if (ImageFile != null && ImageFile.Length > 0)
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

            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = "Foods updated successfully";
                return RedirectToPage("./ManageFoods");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(food.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool FoodExists(int id)
        {
            return _context.FoodAndDrinks.Any(e => e.Id == id);
        }
    }
}
