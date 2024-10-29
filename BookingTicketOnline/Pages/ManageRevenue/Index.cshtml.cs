using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketOnline.Pages.ManagerRevenue
{
    public class IndexModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public IndexModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Revenue> Revenue { get; set; } = default!;

        // Thêm thuộc tính cho ngày bắt đầu và ngày kết thúc
        [BindProperty(SupportsGet = true)]
        public DateTime? FromDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public DateTime? ToDate { get; set; }

        public async Task OnGetAsync()
        {
            var revenueQuery = _context.Revenues.AsQueryable();

            // Lọc theo ngày nếu được chỉ định
            if (FromDate.HasValue)
            {
                revenueQuery = revenueQuery.Where(r => r.FromDate >= FromDate.Value);
            }
            if (ToDate.HasValue)
            {
                revenueQuery = revenueQuery.Where(r => r.ToDate <= ToDate.Value);
            }

            Revenue = await revenueQuery.ToListAsync();
        }
    }
}
