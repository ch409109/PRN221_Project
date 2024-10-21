using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages
{
    public class VerifyCodeModel : PageModel
    {
        [BindProperty]
        public string Code { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            var storedCode = HttpContext.Session.GetString("VerificationCode");
            var email = HttpContext.Session.GetString("Email");
            var storedTimeStr = HttpContext.Session.GetString("VerificationCodeTime");

            if (string.IsNullOrEmpty(storedTimeStr))
            {
                ModelState.AddModelError("", "Verification code has expired.");
                return Page();
            }
            // Chuyển đổi thời gian từ session (UTC) thành kiểu DateTime
            var storedTime = DateTime.Parse(storedTimeStr);
            var currentTime = DateTime.UtcNow;

            // Kiểm tra xem đã quá 30 giây chưa
            if (currentTime.Subtract(storedTime).TotalSeconds > 60)
            {
                ModelState.AddModelError("", "Verification code has expired.");
                return Page();
            }

            if (storedCode == Code)
            {
                // Mã hợp lệ, chuyển hướng tới trang ResetPassword
                return RedirectToPage("ResetPassword");
            }
            else
            {
                ModelState.AddModelError("", "Invalid verification code.");
                return Page();
            }
        }
    }
}
