using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;
using System.Security.Claims;

namespace BookingTicketOnline.Pages.ManageDiscount
{
    public class EditModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public EditModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);
            if (discount == null)
            {
                return NotFound();
            }
            Discount = discount;
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var existingDiscount = await _context.Discounts
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == Discount.Id);

            if (existingDiscount == null)
            {
                return NotFound();
            }

            existingDiscount.Code = Discount.Code;
            existingDiscount.DiscountValue = Discount.DiscountValue;
            existingDiscount.EndDate = Discount.EndDate;

            _context.Attach(existingDiscount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                TempData["success"] = "Discount voucher updated successfully";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountExists(Discount.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiscountExists(int id)
        {
            return (_context.Discounts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
