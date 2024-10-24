using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace BookingTicketOnline.Pages
{
    public class UserProfileModel : PageModel
    {
        public string? FullName { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Password { get; set; }
        public DateTime? Dob { get; set; }
        public string? Role { get; set; }
        public void OnGet()
        {
            var userClaims = User.Claims;
            Username = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            FullName = userClaims.FirstOrDefault(c => c.Type == "FullName")?.Value;
            Email = userClaims.FirstOrDefault(c => c.Type == "Email")?.Value;
            PhoneNumber = userClaims.FirstOrDefault(c => c.Type == "PhoneNumber")?.Value;
            Password = userClaims.FirstOrDefault(c => c.Type == "Password")?.Value;
            Dob = DateTime.TryParse(userClaims.FirstOrDefault(c => c.Type == ClaimTypes.DateOfBirth)?.Value, out var parsedDob) ? parsedDob: (DateTime?)null;
            Role = userClaims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }
    }
}
