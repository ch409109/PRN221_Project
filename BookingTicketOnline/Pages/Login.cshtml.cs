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

        private readonly PRN221_FinalProjectContext _context;

        public Models.User User { get; set; }
        private IHttpContextAccessor Accessor;

        private IRequestCookieCollection Cookies
        {
            get
            {
                return this.Accessor.HttpContext.Request.Cookies;
            }
        }

        public LoginModel(PRN221_FinalProjectContext context, IHttpContextAccessor _accessor)
        {
            _context = context;
            this.Accessor = _accessor;
        }



        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public bool RememberMe { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            if (this.Cookies["UserName"] != null && this.Cookies["Password"] != null)
            {
                Username = this.Cookies["UserName"];
                Password = this.Cookies["Password"];
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var user = _context.Users.FirstOrDefault(u => u.Username == Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user.Password)) // So sánh mật khẩu đã mã hóa
            {
                ErrorMessage = "Invalid login attempt.";
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


            if (RememberMe)
            {
                CookieOptions options = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30),
                    HttpOnly = true, // Để ngăn truy cập từ JavaScript
                    Secure = true // Bảo mật bằng HTTPS
                };
                Response.Cookies.Append("UserName", Username, options);
                Response.Cookies.Append("Password", Password, options);
            }
            else
            {
                Response.Cookies.Delete("UserName");
                Response.Cookies.Delete("Password");
            }


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
