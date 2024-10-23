using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Seat
{
	public class ManageSeatsModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;

		public ManageSeatsModel(PRN221_FinalProjectContext context)
		{
			_context = context;
		}
		public Models.Seat Seat { get; set; }
		public IList<Models.Row> rows { get; set; }

		public async Task OnGetAsync()
		{

		}
	}
}
