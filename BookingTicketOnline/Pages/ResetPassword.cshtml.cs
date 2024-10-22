using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages
{
    public class ResetPasswordModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context; // Truy cập trực tiếp vào DbContext

        public ResetPasswordModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Kiểm tra nếu mật khẩu và xác nhận mật khẩu không khớp
            if (Password != ConfirmPassword)
            {
                ModelState.AddModelError("", "Passwords do not match.");
                return Page();
            }
            // Lấy email từ session
            var email = HttpContext.Session.GetString("Email");

            // Tìm người dùng trong cơ sở dữ liệu dựa trên email
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                ModelState.AddModelError("", "User not found.");
                return Page();
            }

            // Cập nhật mật khẩu mới cho người dùng
            user.Password = BCrypt.Net.BCrypt.HashPassword(Password);

            // Lưu thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            // Điều hướng người dùng đến trang login sau khi cập nhật thành công
            return RedirectToPage("Login");
        }
    }
}
