using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Implementations;
using BookingTicketOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text.Json;

namespace BookingTicketOnline.Pages.Payment
{
    public class PaymentCallbackModel : PageModel
    {
        private readonly IVNPayService _vnPayService;
        private readonly BookingService _bookingService;
        private readonly EmailService _emailService;
        private ILogger<PaymentCallbackModel> _logger;
        
        public PaymentResponseModel PaymentResponse { get; set; } = new();

        public PaymentCallbackModel(IVNPayService vnPayService, BookingService bookingService, ILogger<PaymentCallbackModel> logger, EmailService emailService)
        {
            _vnPayService = vnPayService;
            _bookingService = bookingService;
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                PaymentResponse = _vnPayService.PaymentExecute(Request.Query);

                if (PaymentResponse.Success)
                {
                    // Lấy dữ liệu từ session
                    var selectedItemsJson = HttpContext.Session.GetString("SelectedItems");
                    // Chuyển đổi JSON thành List<(int FoodAndDrinkId, int Quantity)>
                    var selectedItems = selectedItemsJson != null
                        ? JsonSerializer.Deserialize<List<Item>>(selectedItemsJson)?
                            .Select(item => (FoodAndDrinkId: item.Id, Quantity: item.Quantity))
                            .ToList()
                        : new List<(int FoodAndDrinkId, int Quantity)>();

                    var totalPrice = HttpContext.Session.GetInt32("TotalPrice") ?? 0;
                    var discountId = HttpContext.Session.GetInt32("DiscountId");

                    // Xử lý đặt vé
                    var result = await _bookingService.ProcessBookingAsync(
                        totalPrice,
                        selectedItems,
                        discountId
                    );

                    var userEmail = User.FindFirst("Email")?.Value;
                    if (!string.IsNullOrEmpty(userEmail))
                    {
                        var subject = "Booking Confirmation";
                        var message = $"<h1>Thank you for your booking!</h1>" +
                                      $"<p>Your booking has been successfully completed.</p>" +
                                      $"<p><strong>Total Price:</strong> {result.TotalPrice}</p>" +
                                      $"<p><strong>Ticket Code:</strong> {result.TicketCode}</p>" +
                                      $"<p><strong>Booking Date:</strong> {result.BookingDate?.ToString("f")}</p>";

                        await _emailService.SendEmailAsync(userEmail, subject, message);
                    }

                    // Xóa dữ liệu session
                    HttpContext.Session.Remove("SelectedItems");
                    HttpContext.Session.Remove("TotalPrice");
                    HttpContext.Session.Remove("DiscountId");
                    HttpContext.Session.Remove("FoodQuantities");
                    HttpContext.Session.Remove("FoodTotalAmount");

                    return RedirectToPage("/Payment/PaymentSuccess");
                }

                return RedirectToPage("/Payment/PaymentFailed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing payment callback");
                return RedirectToPage("/Payment/PaymentFailed");
            }
        }
    }
}
