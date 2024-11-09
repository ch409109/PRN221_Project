using BookingTicketOnline.Models;
using BookingTicketOnline.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public int SeatTotalAmount { get; set; }
        public int FoodTotalAmount { get; set; }
        public int TotalAmount { get; set; }
        public int DiscountAmount { get; set; }
        public int FinalAmount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Login", new { ReturnUrl = "/CheckOut" });
            }

            LoadAmountsFromSession();
            var discountId = HttpContext.Session.GetInt32("DiscountId");
            if (discountId.HasValue)
            {
                var discount = await _context.Discounts.FindAsync(discountId.Value);
                if (discount != null)
                {
                    DiscountAmount = (int)(TotalAmount * ((decimal)discount.DiscountValue / 100));
                }
            }

            FinalAmount = TotalAmount - DiscountAmount;
            return Page();
        }

        private void LoadAmountsFromSession()
        {
            // Lấy tổng tiền ghế
            SeatTotalAmount = HttpContext.Session.GetInt32("SeatTotalAmount") ?? 0;

            // Lấy tổng tiền đồ ăn
            FoodTotalAmount = HttpContext.Session.GetInt32("FoodTotalAmount") ?? 0;

            // Tính tổng tiền
            TotalAmount = SeatTotalAmount + FoodTotalAmount;
        }

        public async Task<IActionResult> OnPostApplyVoucherAsync()
        {
            LoadAmountsFromSession();

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

            if (discount != null)
            {
                HttpContext.Session.SetInt32("DiscountId", discount.Id);
            }

            DiscountAmount = (int)(TotalAmount * ((decimal)discount.DiscountValue / 100));
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

            LoadAmountsFromSession();

            var discountId = HttpContext.Session.GetInt32("DiscountId");
            if (discountId.HasValue)
            {
                var discount = await _context.Discounts.FindAsync(discountId.Value);
                if (discount != null)
                {
                    DiscountAmount = (int)(TotalAmount * ((decimal)discount.DiscountValue / 100));
                }
            }

            FinalAmount = TotalAmount - DiscountAmount;
            HttpContext.Session.SetInt32("TotalPrice", FinalAmount);

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
                $"{Request.Scheme}://{Request.Host}/Payment/PaymentCallback");

            return Redirect(url);
        }
    }
}