using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.ManageNews
{
    public class CreateNewsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateNewsModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Models.News news { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

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

            if (ImageFile != null)
            {
                var originalFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var fileExtension = Path.GetExtension(ImageFile.FileName);
                var fileName = $"{Guid.NewGuid()}_{originalFileName}{fileExtension}";
                var filePath = Path.Combine(_environment.WebRootPath, "img/NewsImage", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                news.Image = fileName;
            }
            news.CreateAt = DateTime.Now;
            news.UpdateAt = DateTime.Now;

            _context.News.Add(news);
            await _context.SaveChangesAsync();
            TempData["success"] = "News created successfully";

            return RedirectToPage("./ManageNews");
        }
    }
}
