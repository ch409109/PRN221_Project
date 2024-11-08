using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Implementations;
using BookingTicketOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BookingTicketOnline.Pages.Payment
{
    public class PaymentCallbackModel : PageModel
    {
        private readonly IVNPayService _vnPayService;
        private readonly BookingService _bookingService;

        public PaymentResponseModel PaymentResponse { get; set; } = new();

        public PaymentCallbackModel(IVNPayService vnPayService, BookingService bookingService)
        {
            _vnPayService = vnPayService;
            _bookingService = bookingService;
        }

        public async Task<IActionResult> OnGet()
        {
            PaymentResponse = _vnPayService.PaymentExecute(Request.Query);

            if (PaymentResponse.Success)
            {
                // Thêm code cập nhật database ở đây
                var selectedItemsJson = HttpContext.Session.GetString("SelectedItems");
                var selectedItems = selectedItemsJson != null ? JsonSerializer.Deserialize<List<Item>>(selectedItemsJson)
                                                              : new List<Item>();
                var selectedItemsProcessed = selectedItems.Select(item => (item.Id, item.Quantity)).ToList();

                var bookingDate = DateTime.Now;
                var discountId = HttpContext.Session.GetInt32("DiscountId");
                var userId = User.FindFirst("UserId")?.Value;
                int? cinemaId = null; ;
                int? movieId = HttpContext.Session.GetInt32("MovieId");

                await _bookingService.ProcessBookingAsync(cinemaId, movieId, selectedItemsProcessed, discountId);
                return RedirectToPage("/Payment/PaymentSuccess");
            }

            return RedirectToPage("/Payment/PaymentFailed");
        }
    }
}
