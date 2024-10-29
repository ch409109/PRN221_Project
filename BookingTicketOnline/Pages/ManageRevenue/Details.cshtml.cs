
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;
using BookingTicketOnline.DTO;


namespace BookingTicketOnline.Pages.ManagerRevenue

{
    public class DetailsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public DetailsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public Revenue Revenue { get; set; }

        // New property for revenue details
        public RevenueDetailDto RevenueDetails { get; set; } = new RevenueDetailDto();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Lấy thông tin doanh thu
            Revenue = await _context.Revenues
                .Include(r => r.Payment) // Bao gồm dữ liệu Payment nếu cần
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Revenue == null)
            {
                return NotFound();
            }

            // Tính toán TicketSales từ TotalPrice của mô hình Booking
            RevenueDetails.TicketSales = await _context.Bookings
                .Where(b => b.Id == Revenue.Payment.BookingId) // Ví dụ về điều kiện lọc
                .SumAsync(b => (decimal?)b.TotalPrice) ?? 0; // Cung cấp giá trị mặc định là 0 nếu null

            // Tính toán Concessions từ DiscountValue của Payment
            RevenueDetails.Concessions = await _context.Payments
                .Where(p => p.DiscountId == p.Discount.Id) // Ví dụ về điều kiện lọc
                .SumAsync(p => (decimal?)p.Discount.DiscountValue) ?? 0; // Cung cấp giá trị mặc định là 0 nếu null
                                                                         // Tính toán OtherIncome từ TotalPrice của BookingItem
            RevenueDetails.OtherIncome = await _context.BookingItems
                .Where(bi => bi.BookingId == bi.Booking.Id)
                .SumAsync(bi => (decimal?)bi.Price) ?? 0; // Cung cấp giá trị mặc định là 0 nếu null


            return Page();

        }
    }
}
