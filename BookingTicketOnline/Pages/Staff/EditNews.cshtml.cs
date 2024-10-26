using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.ManageNews
{
    public class EditNewsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public Models.News news { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public EditNewsModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            news = await _context.News.AsNoTracking().FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
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

            var newsToUpdate = await _context.News.AsNoTracking().FirstOrDefaultAsync(f => f.Id == news.Id);

            if (newsToUpdate == null)
            {
                return NotFound();
            }

            news.Title = newsToUpdate.Title;
            news.Image = newsToUpdate.Image;
            news.Content = newsToUpdate.Content;
            news.UpdateAt = DateTime.Now;

           
           

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var originalFileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                var fileExtension = Path.GetExtension(ImageFile.FileName);
                var fileName = $"{Guid.NewGuid()}_{originalFileName}{fileExtension}";
                var filePath = Path.Combine(_environment.WebRootPath, "img/NewsImage", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await ImageFile.CopyToAsync(stream);
                }

                if (!string.IsNullOrEmpty(newsToUpdate.Image))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, "img/NewsImage", newsToUpdate.Image);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                newsToUpdate.Image = fileName;
            }

            _context.Attach(newsToUpdate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = "News updated successfully";
                return RedirectToPage("./ManageNews");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewsExists(news.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool NewsExists(int id)
        {
            return _context.News.Any(n => n.Id == id);
        }
    }
}
