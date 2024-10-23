using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.User
{
	public class CreateUserModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;
		public CreateUserModel(PRN221_FinalProjectContext context)
		{
			_context = context;
		}
		public IList<Role> Roles { get; set; }

		public void OnGetAsync()
		{

		}
	}
}
