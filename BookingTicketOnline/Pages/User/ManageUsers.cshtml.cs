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
		}

		[BindProperty(SupportsGet = true)]
		public string SearchTerm { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedStatus { get; set; }

		[BindProperty(SupportsGet = true)]
		public string SelectedRole { get; set; }

		[BindProperty]
		public string Msg { get; set; }

		[BindProperty(SupportsGet = true)]
		public int CurrentPage { get; set; } = 1;
		public int PageSize { get; set; } = 5;
		public int TotalPages { get; set; }
		public IList<Models.User> Users { get; set; }

		public async Task OnGetAsync()
		{
			await LoadUsersAsync();
		}

		public async Task OnPostSearchAsync()
		{
			await LoadUsersAsync();
		}

		private async Task LoadUsersAsync()
		{
            UsersSource = await _context.Users.Include(r => r.Role).ToListAsync();

            var listUsers = UsersSource
				.Where(item => (string.IsNullOrWhiteSpace(SearchTerm) || item.FullName.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase) 
				|| item.Email.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)) &&
							   (string.IsNullOrWhiteSpace(SelectedRole) || item.Role.RoleName.Equals(SelectedRole, StringComparison.OrdinalIgnoreCase)) &&
							   (string.IsNullOrWhiteSpace(SelectedStatus) || item.Status.Equals(SelectedStatus, StringComparison.OrdinalIgnoreCase)));

			int totalUsers = listUsers.Count();
			TotalPages = (int)Math.Ceiling(totalUsers / (double)PageSize);

			Users = listUsers
				.Skip((CurrentPage - 1) * PageSize)
				.Take(PageSize)
				.ToList();
			Msg = totalUsers + " records found";
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);

			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
				Msg = $"User with ID {id} has been deleted successfully.";
			}
			else
			{
				Msg = "User not found.";
			}

			await LoadUsersAsync(); 
			return RedirectToPage();
		}

	}
}
