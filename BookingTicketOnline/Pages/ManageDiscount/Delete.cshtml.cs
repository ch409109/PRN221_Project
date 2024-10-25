using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;

namespace BookingTicketOnline.Pages.ManageDiscount
{
    public class DeleteModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public DeleteModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }

            var discount = await _context.Discounts.FirstOrDefaultAsync(m => m.Id == id);

            if (discount == null)
            {
                return NotFound();
            }
            else
            {
                Discount = discount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Discounts == null)
            {
                return NotFound();
            }
            var discount = await _context.Discounts.FindAsync(id);

            if (discount != null)
            {
                Discount = discount;
                _context.Discounts.Remove(Discount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
