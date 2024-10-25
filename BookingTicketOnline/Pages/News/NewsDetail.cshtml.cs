using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace BookingTicketOnline.Pages.News
{
    public class NewsDetailModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        // Declare a public News property
        public BookingTicketOnline.Models.News News { get; set; }

        public NewsDetailModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the news item by ID from the database
            News = await _context.News.FindAsync(id);

            // Handle case where news item is not found
            if (News == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
