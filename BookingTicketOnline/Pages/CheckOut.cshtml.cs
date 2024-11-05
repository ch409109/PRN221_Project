using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json;

namespace BookingTicketOnline.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly IVNPayService _vNPayService;
        private readonly IConfiguration _configuration;
        private readonly PRN221_FinalProjectContext _context;

        public CheckOutModel(IVNPayService vNPayService, IConfiguration configuration, PRN221_FinalProjectContext context)
        {
            _vNPayService = vNPayService;
            _configuration = configuration;
            _context = context;
        }

        [BindProperty]
        public string? VoucherCode { get; set; }

        [BindProperty]
        public string PaymentMethod { get; set; } = "VNPay";

        public decimal TotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal FinalAmount { get; set; }
        public void OnGet()
        {
            LoadTotalAmountFromSession();

            DiscountAmount = 0;
            FinalAmount = TotalAmount - DiscountAmount;
        }

        private void LoadTotalAmountFromSession()
        {
            var foodTotalStr = HttpContext.Session.GetString("FoodTotalAmount");
            if (!string.IsNullOrEmpty(foodTotalStr))
            {
                TotalAmount = JsonSerializer.Deserialize<decimal>(foodTotalStr);
            }
            else
            {
                TotalAmount = 0;
            }
        }
        public async Task<IActionResult> OnPostApplyVoucherAsync()
        {
            LoadTotalAmountFromSession();

            if (string.IsNullOrWhiteSpace(VoucherCode))
            {
                ModelState.AddModelError("VoucherCode", "Please enter a discount code");
                FinalAmount = TotalAmount;
                return Page();
            }

            var discount = _context.Discounts.FirstOrDefault(d => d.Code == VoucherCode && d.EndDate >= DateTime.Now);

            if (discount == null || discount.EndDate < DateTime.Now)
            {
                ModelState.AddModelError("VoucherCode", "Invalid or expired discount code");
                FinalAmount = TotalAmount;
                return Page();
            }

            DiscountAmount = TotalAmount * (discount.DiscountValue / 100);
            FinalAmount = TotalAmount - DiscountAmount;

            ViewData["VoucherMessage"] = "Discount code applied successfully. Total updated.";

            ModelState.Clear();

            return Page();
        }

        public async Task<IActionResult> OnPostCheckoutAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var payment = new PaymentInformation
            {
                OrderType = "billpayment",
                Amount = FinalAmount,
                OrderDescription = "Thanh toan ve xem phim",
                Name = "Thanh toan ve xem phim",
                OrderId = DateTime.Now.Ticks.ToString(),
                IpAddress = HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1"
            };

            var url = _vNPayService.CreatePaymentUrl(payment,
                $"{Request.Scheme}://{Request.Host}/PaymentCallback");

            return Redirect(url);
        }
    }
}
