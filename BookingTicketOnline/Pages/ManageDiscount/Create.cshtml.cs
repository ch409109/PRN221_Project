using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookingTicketOnline.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

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
            var roleIdClaim = User.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleIdClaim) || roleIdClaim != "3")
            {
                return RedirectToPage("/AccessDenied");
            }

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

            var discountCodeExists = await _context.Discounts
               .AnyAsync(d => d.Code == Discount.Code && d.Id != Discount.Id);

            if (discountCodeExists)
            {
                TempData["error"] = "Mã giảm giá này đã tồn tại !!!";
                return Page();
            }

            if (Discount.StartDate < DateTime.Today)
            {
                TempData["error"] = "Ngày bắt đầu không hợp lệ !!!";
                return Page();
            }

            if (Discount.StartDate > Discount.EndDate)
            {
                TempData["error"] = "Ngày bắt đầu phải nhỏ hơn ngày kết thúc !!!";
                return Page();
            }

            _context.Discounts.Add(Discount);
            await _context.SaveChangesAsync();
            TempData["success"] = "Discount voucher created successfully";

            return RedirectToPage("./Index");
        }

    }
}
