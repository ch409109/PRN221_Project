using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingTicketOnline.Models; // Import user model
using System.Linq; // For LINQ queries
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BookingTicketOnline.Pages
{
    public class LoginModel : PageModel
    {
        // Fake database context. Replace this with your actual DbContext
        private readonly PRN221_FinalProjectContext _context;

        public LoginModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);

            if (user == null)
            {
                ErrorMessage = "Invalid username or password";
                return Page();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim("FullName", user.FullName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            switch (user.RoleId)
            {
                case 1:
                    return RedirectToPage("/HomeAdmin");
                case 2:
                    return RedirectToPage("/Index"); 
                case 3:
                    return RedirectToPage("/HomeStaff"); 
                default:
                    return Page(); 
            }
        }
    }
}
