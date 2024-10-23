using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Movie
{
    public class EditMovieModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;

        [BindProperty]
        public Models.Movie movie { get; set; }

        [BindProperty]
        public IFormFile ImageFile { get; set; }

        public List<MovieCategory> categories { get; set; }

        public EditMovieModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            movie = await _context.Movies.FindAsync(id);
            categories = _context.MovieCategories.ToList();

            if (movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                categories = _context.MovieCategories.ToList();
                return Page();
            }

            var movieToUpdate = await _context.Movies.FindAsync(movie.Id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            movieToUpdate.Title = movie.Title;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            movieToUpdate.Actor = movie.Actor;
            movieToUpdate.Director = movie.Director;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.TrailerUrl = movie.TrailerUrl;
            movieToUpdate.Status = movie.Status;
            movieToUpdate.CategoryId = movie.CategoryId;

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

                if (!string.IsNullOrEmpty(movieToUpdate.Poster))
                {
                    var oldImagePath = Path.Combine(_environment.WebRootPath, "img", movieToUpdate.Poster);
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                movieToUpdate.Poster = fileName;
            }

            _context.Attach(movieToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            TempData["success"] = "Movie updated successfully";

            return RedirectToPage("./ManageMovies");
        }
    }
}
