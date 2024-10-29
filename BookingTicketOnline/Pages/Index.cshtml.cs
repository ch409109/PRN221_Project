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

    public List<Movie> Movies { get; set; }

    public async Task OnGetAsync()
    {
        // Include the Category when fetching Movies
        Movies = await _context.Movies
            .Include(m => m.Category) // Include the related Category
            .ToListAsync();
    }
}
