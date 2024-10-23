using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.Movie
{
    public class CreateMovieModel : PageModel
    {
        public List<MovieCategory> categories { get; set; }
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        public CreateMovieModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Models.Movie movie { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public IActionResult OnGet()
        {
            categories = _context.MovieCategories.ToList();
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                categories = _context.MovieCategories.ToList();
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
                    ImageFile.CopyTo(stream);
                }

                movie.Poster = fileName;
            }

            movie.Status = "Active";

            _context.Movies.Add(movie);
            _context.SaveChanges();
            TempData["success"] = "Movie created successfully";

            return RedirectToPage("./ManageMovies");
        }
    }
}
