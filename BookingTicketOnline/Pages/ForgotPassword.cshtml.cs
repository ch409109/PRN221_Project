using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly EmailService _emailService;
      
        public ForgotPasswordModel(EmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public string Email { get; set; }

        public string VerificationCode { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Email))
            {
                ModelState.AddModelError("", "Email is required.");
                return Page();
            }

            // Tạo mã xác thực
            VerificationCode = GenerateVerificationCode();

            // Lưu mã xác thực vào session (hoặc database nếu muốn)
            HttpContext.Session.SetString("VerificationCode", VerificationCode);
            HttpContext.Session.SetString("Email", Email);

            // Lưu thời gian hiện tại (UTC) khi mã được tạo
            HttpContext.Session.SetString("VerificationCodeTime", DateTime.UtcNow.ToString());

            // Gửi mã xác thực qua email
            var subject = "Password Reset Verification Code";
            var message = $"Your verification code is: {VerificationCode}";
            await _emailService.SendEmailAsync(Email, subject, message);

            // Chuyển hướng tới trang nhập mã xác thực
             return RedirectToPage("VerifyCode", new { email = Email });
        }

        private string GenerateVerificationCode()
        {
            var random = new Random();
            return random.Next(100000, 999999).ToString(); // Tạo mã xác thực 6 chữ số
        }
    }
}
