using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.ManageNews
{
	public class ManageNewsModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;
		public List<Models.News> NewsSource { get; set; }
		public ManageNewsModel(PRN221_FinalProjectContext context)
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
		public IList<Models.News> News { get; set; }

		public async Task OnGetAsync()
		{
			await LoadNewsAsync();
		}

		public async Task OnPostSearchAsync()
		{
			await LoadNewsAsync();
		}

		private async Task LoadNewsAsync()
		{
			NewsSource = await _context.News.ToListAsync();

			var listNews = NewsSource
			   .Where(item => (string.IsNullOrWhiteSpace(SearchTerm) || item.Title.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)));

			int totalNews = listNews.Count();
			TotalPages = (int)Math.Ceiling(totalNews / (double)PageSize);

			News = listNews
				.Skip((CurrentPage - 1) * PageSize)
				.Take(PageSize)
				.ToList();
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var news = await _context.News.FindAsync(id);

			if (news != null)
			{
				_context.News.Remove(news);
				await _context.SaveChangesAsync();
				Msg = $"News with ID {id} has been deleted successfully.";
			}
			else
			{
				Msg = "User not found.";
			}

			await LoadNewsAsync();
			return RedirectToPage();
		}

	}
}
