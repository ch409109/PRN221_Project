using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.ManageDiscount
{
    public class IndexModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public IndexModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Discount> Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

            if (_context.Discounts != null)
            {
                Discount = await _context.Discounts.ToListAsync();
            }

            return Page();
        }
    }
}
