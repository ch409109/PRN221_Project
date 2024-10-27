using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace BookingTicketOnline.Pages
{
    public class UserProfileModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        public UserProfileModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string? FullName { get; set; }
        public string? Username { get; set; }
        [BindProperty]
        public string? Email { get; set; }
        [BindProperty]
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        [BindProperty]
        public DateTime? Dob { get; set; }
        public string? Role { get; set; }

        [BindProperty]
        public string? NewPassword { get; set; }

        [BindProperty]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu xác nhận không khớp")]
        public string? ConfirmPassword { get; set; }
        public void OnGet()
        {
            var userClaims = User.Claims;
            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            if (username != null)
            {
                var user = _context.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    FullName = user.FullName;
                    Email = user.Email;
                    PhoneNumber = user.PhoneNumber;
                    Dob = user.Dob;
                }
            }
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var userClaims = User.Claims;
            var username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;

            if (username == null) return NotFound();

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null) return NotFound();

            user.FullName = FullName;
            user.Email = Email;
            user.PhoneNumber = PhoneNumber;
            user.Dob = Dob;

            if (!string.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmPassword)
            {
                user.Password = BCrypt.Net.BCrypt.HashPassword(NewPassword);
            }

            await _context.SaveChangesAsync();

            return RedirectToPage("/UserProfile");
        }
    }
}