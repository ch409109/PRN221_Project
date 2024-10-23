using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Movie
{
    public class ManageMoviesModel : PageModel
    {
        public List<MovieCategory> categories { get; set; }
        public List<Models.Movie> movies = new List<Models.Movie>();

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        private readonly PRN221_FinalProjectContext _context;

        public ManageMoviesModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString, int pageNumber = 1)
        {
            var totalItems = await _context.Movies.CountAsync();

            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            CurrentPage = pageNumber;

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }

            IQueryable<Models.Movie> movieQuery = _context.Movies;

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                movieQuery = movieQuery.Where(f => f.Title.Contains(CurrentFilter));
            }

            movies = await movieQuery
                .OrderBy(c => c.Title)
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            categories = await _context.MovieCategories.ToListAsync();
        }
    }
}
