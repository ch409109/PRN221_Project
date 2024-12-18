using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.News
{
    public class BlogModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public BlogModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        [BindProperty]
        public string Msg { get; set; }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int TotalPages { get; set; }

        public List<Models.News> NewsSource { get; set; }
        public IList<Models.News> News { get; set; }

        public async Task OnGetAsync()
        {
          await LoadNewsAsync();
        }

        private async Task LoadNewsAsync()
        {
            NewsSource = await _context.News.Include(n => n.CreateByNavigation).OrderByDescending(n => n.CreateAt).ToListAsync();

            var listNews = NewsSource
               .Where(item => (string.IsNullOrWhiteSpace(SearchTerm) || item.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)));

            int totalNews = listNews.Count();
            TotalPages = (int)Math.Ceiling(totalNews / (double)PageSize);

            News = listNews
                .Skip((CurrentPage - 1) * PageSize)
                .Take(PageSize)
                .ToList();
        }

        public async Task OnPostSearchAsync()
        {
            await LoadNewsAsync();
        }
    }
}
