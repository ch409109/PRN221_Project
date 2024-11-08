using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages
{
	public class BookingHistoryModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;
		public BookingHistoryModel(PRN221_FinalProjectContext context)
		{
			_context = context;
		}
		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;
		public int PageSize { get; set; } = 6;
		public int TotalPages { get; set; }
		[BindProperty]
		public List<Models.Booking> bookings { get; set; }
		public async Task OnGetAsync()
		{
			//var Bookings = await _context.Bookings
			//			.Include(b => b.Movie)
			//			.Include(b => b.Cinema)
			//				.ThenInclude(c => c.Showtimes)
			//			.Include(b => b.BookingSeatsDetails)
			//				.ThenInclude(bsd => bsd.Seat)
			//			.Include(b => b.BookingItems)
			//				.ThenInclude(bi => bi.FoodAndDrinks)
			//			.ToListAsync();
			//TotalPages = (int)Math.Ceiling(Bookings.Count / (double)PageSize);

			//bookings = Bookings.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();

		}
	}
}
