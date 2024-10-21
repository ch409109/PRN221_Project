using System.Net.Mail;
using System.Net;

namespace BookingTicketOnline
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            // Đọc thông tin SMTP từ cấu hình
            var smtpSettings = _configuration.GetSection("SmtpSettings");

            // Tạo SMTP client
            var smtpClient = new SmtpClient(smtpSettings["Server"])
            {
                Port = int.Parse(smtpSettings["Port"]),
                Credentials = new NetworkCredential(smtpSettings["Username"], smtpSettings["Password"]),
                EnableSsl = true,
            };

            // Tạo email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings["SenderEmail"], smtpSettings["SenderName"]),
                Subject = subject,
                Body = message,
                IsBodyHtml = true, // Cho phép sử dụng HTML trong nội dung email
            };

            mailMessage.To.Add(email); // Địa chỉ email người nhận

            // Gửi email
            await smtpClient.SendMailAsync(mailMessage);
        }
    }
}
