using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;

namespace BookingTicketOnline.Pages
{
    public class CheckOutModel : PageModel
    {
        [BindProperty]
        public string? VoucherCode { get; set; }

        [BindProperty]
        public string PaymentMethod { get; set; } = "VNPay";

        //[BindProperty]
        //[Required(ErrorMessage = "You must agree to the terms and conditions")]
        //public bool AgreeToTerms { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }

        //private readonly IVoucherService _voucherService;
        //private readonly IPaymentService _paymentService;

        //public CheckOutModel(IVoucherService voucherService, IPaymentService paymentService)
        //{
        //    _voucherService = voucherService;
        //    _paymentService = paymentService;
        //}

        public CheckOutModel()
        {
            
        }

        public void OnGet()
        {
            // Load booking details from session or database
            // This is just example data
            //TotalAmount = 50.00M;
            //DiscountAmount = 0;
            //FinalAmount = TotalAmount - DiscountAmount;

            var foodTotalStr = HttpContext.Session.GetString("FoodTotalAmount");
            if (!string.IsNullOrEmpty(foodTotalStr))
            {
                TotalAmount = JsonSerializer.Deserialize<decimal>(foodTotalStr);
            }
            else
            {
                TotalAmount = 0;
            }

            // Tính toán giá cuối cùng
            DiscountAmount = 0; // Hoặc lấy từ service nếu có
            FinalAmount = TotalAmount - DiscountAmount;
        }

        public async Task<IActionResult> OnPostApplyVoucherAsync()
        {
            if (string.IsNullOrWhiteSpace(VoucherCode))
            {
                return BadRequest("Please enter a discount code");
            }

            //var discount = await _voucherservice.validateandgetdiscountasync(vouchercode);
            //if (discount > 0)
            //{
            //    DiscountAmount = discount;
            //    FinalAmount = TotalAmount - DiscountAmount;
            //    return new JsonResult(new
            //    {
            //        success = true,
            //        discountAmount = DiscountAmount,
            //        finalAmount = FinalAmount
            //    });
            //}

            return BadRequest("Invalid discount code");
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Process payment with VNPay
            //var paymentUrl = await _paymentService.CreatePaymentUrl(
            //    amount: FinalAmount,
            //    orderDescription: "Movie Ticket Payment",
            //    orderType: "billpayment"
            //);

            return Redirect(null);
        }
    }
}
