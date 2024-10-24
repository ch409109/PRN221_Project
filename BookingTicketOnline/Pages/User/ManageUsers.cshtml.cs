using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.User
{
	public class ManageUsersModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;
		public List<Models.User> UsersSource { get; set; }
		public ManageUsersModel(PRN221_FinalProjectContext context)
		{
			_context = context;
			UsersSource = _context.Users.Include(r => r.Role).ToList();
		}

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedStatus { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedRole { get; set; }

		[BindProperty] 
		public string Msg { get; set; }

		public IList<Models.User> Users { get; set; }

		public async Task OnGetAsync()
		{
			Users = UsersSource;
		}

		public async Task OnPostSearchAsync()
		{
			Users = new List<Models.User>();

            if (string.IsNullOrWhiteSpace(SearchTerm))
            {
				SearchTerm = "";
            }
            if (string.IsNullOrWhiteSpace(SearchTerm) && string.IsNullOrWhiteSpace(SelectedRole) && string.IsNullOrWhiteSpace(SelectedStatus))
            {
				Users = UsersSource;
			}
            else
            {
				foreach (Models.User item in UsersSource)
				{
					if ((item.FullName.Contains(SearchTerm) || item.Email.Contains(SearchTerm))
						&& (item.Role.RoleName.Contains(SelectedRole)) && (item.Status.Contains(SelectedStatus)))
					{
						Users.Add(item);
					}
				}
			}
            
		}

	}
}
