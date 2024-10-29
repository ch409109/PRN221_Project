using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages
{
    public class BookingHistoryModel : PageModel
    {

		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;
		public int PageSize { get; set; } = 5;
		public int TotalPages { get; set; }
		public void OnGet()
        {
        }
    }
}
