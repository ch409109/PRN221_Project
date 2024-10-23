using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.User
{
	public class ManageUsersModel : PageModel
	{
		private readonly PRN221_FinalProjectContext _context;

		public ManageUsersModel(PRN221_FinalProjectContext context)
		{
			_context = context;
		}

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedStatus { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedRole { get; set; }

		[BindProperty]
		public List<Models.User> Users { get; set; }

		public async Task OnGetAsync()
		{
			Users = await _context.Users.Include(r => r.Role).ToListAsync();
		}

		public async Task OnPostSearchAsync()
		{
			IQueryable<Models.User> query = _context.Users.Include(r => r.Role);
			query = query.Where(u => u.FullName.Contains(SearchTerm) || u.Email.Contains(SearchTerm));
			Users = await query.ToListAsync();
		}

		public async Task OnGetFilterAsync()
		{
			IQueryable<Models.User> query = _context.Users;

			if (!string.IsNullOrEmpty(SelectedStatus))
			{
				query = query.Where(u => u.Status == SelectedStatus);
			}

			if (!string.IsNullOrEmpty(SelectedRole))
			{
				query = query.Where(u => u.Role.RoleName == SelectedRole);
			}

			Users = await query.ToListAsync();
		}

	}
}
