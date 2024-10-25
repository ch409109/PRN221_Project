using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingTicketOnline.Models;

namespace BookingTicketOnline.Pages.ManageDiscount
{
    public class CreateModel : PageModel
    {
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public CreateModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Discounts == null || Discount == null)
            {
                return Page();
            }

            _context.Discounts.Add(Discount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
