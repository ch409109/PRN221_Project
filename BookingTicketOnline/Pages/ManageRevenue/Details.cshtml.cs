
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Microsoft.EntityFrameworkCore;
//using BookingTicketOnline.Models;
//using BookingTicketOnline.DTO;


//namespace BookingTicketOnline.Pages.ManagerRevenue

//{
//    public class DetailsModel : PageModel
//    {
//        private readonly PRN221_FinalProjectContext _context;

//        public DetailsModel(PRN221_FinalProjectContext context)
//        {
//            _context = context;
//        }

//        public Revenue Revenue { get; set; }

//        // New property for revenue details
//        public RevenueDetailDto RevenueDetails { get; set; } = new RevenueDetailDto();

//        public async Task<IActionResult> OnGetAsync(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            Revenue = await _context.Revenues
//            .Include(r => r.Cinema)
//            .FirstOrDefaultAsync(m => m.Id == id);

//            if (Revenue == null)
//            {
//                return NotFound();
//            }

//            RevenueDetails.CinemaName = Revenue.Cinema?.Name ?? "Unknown Cinema";

//            return Page();

//        }
//    }
//}
