using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

public class IndexModel : PageModel
{
    private readonly PRN221_FinalProjectContext _context;

    public IndexModel(PRN221_FinalProjectContext context)
    {
        _context = context;
    }

    public List<Movie> OpeningMovies { get; set; }
    public List<Movie> ComingSoonMovies { get; set; }

    public List<Movie> PosterMovies { get; set; }

    public async Task OnGetAsync()
    {
        var currentDate = DateTime.Today;

        // Filter "Opening This Week" movies based on status and release date
        OpeningMovies = await _context.Movies
            .Include(m => m.Category)
            .Where(m => m.Status == "Active" && m.ReleaseDate <= currentDate)
            .ToListAsync();

        // Filter "Coming Soon" movies based on future release dates
        ComingSoonMovies = await _context.Movies
            .Include(m => m.Category)
            .Where(m => m.Status == "Active" && m.ReleaseDate > currentDate)
            .ToListAsync();

        PosterMovies = await _context.Movies
            .Include(m => m.Category)
            .Where(m => m.Status == "Poster")
            .OrderBy(m => Guid.NewGuid())
            .Take(3)
            .ToListAsync();
    }
}
