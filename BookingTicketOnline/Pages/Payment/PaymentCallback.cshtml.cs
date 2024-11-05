using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.Payment
{
    public class PaymentCallbackModel : PageModel
    {
        private readonly IVNPayService _vnPayService;

        public PaymentResponseModel PaymentResponse { get; set; } = new();

        public PaymentCallbackModel(IVNPayService vnPayService)
        {
            _vnPayService = vnPayService;
        }

        public IActionResult OnGet()
        {
            PaymentResponse = _vnPayService.PaymentExecute(Request.Query);

            if (PaymentResponse.Success)
            {
                // Thêm code cập nhật database ở đây
                return RedirectToPage("/Payment/PaymentSuccess");
            }

            return RedirectToPage("/Payment/PaymentFailed");
        }
    }
}
