using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.News
{
    public class BlogDetailModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IWebHostEnvironment _environment;
        public IList<Models.News> News { get; set; }

        [BindProperty]
        public Models.News news { get; set; }

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public BlogDetailModel(PRN221_FinalProjectContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            News = await _context.News.Include(n => n.CreateByNavigation).OrderByDescending(n => n.CreateAt).ToListAsync();
            news = await _context.News.AsNoTracking().Include(n => n.CreateByNavigation).FirstOrDefaultAsync(n => n.Id == id);

            if (news == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
