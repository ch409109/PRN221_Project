using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public SelectList CinemaList { get; set; } = default!;
        public SelectList YearList { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int? SelectedCinemaId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedQuarter { get; set; }

        public async Task OnGetAsync()
        {
            await LoadDataAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            SelectedCinemaId = null;
            SelectedYear = null;
            SelectedQuarter = null;

            await LoadDataAsync();
            return Page();
        }
        private async Task LoadDataAsync()
        {
            CinemaList = new SelectList(await _context.Cinemas.ToListAsync(), "Id", "Name");
            YearList = new SelectList(await _context.Revenues.Select(r => r.Year).Distinct().ToListAsync());

            var revenueQuery = _context.Revenues.Include(r => r.Cinema).AsQueryable();

            if (SelectedCinemaId.HasValue)
            {
                revenueQuery = revenueQuery.Where(r => r.CinemaId == SelectedCinemaId.Value);
            }
            if (SelectedYear.HasValue)
            {
                revenueQuery = revenueQuery.Where(r => r.Year == SelectedYear.Value);
            }
            if (SelectedQuarter.HasValue)
            {
                revenueQuery = revenueQuery.Where(r => r.Quarter == SelectedQuarter.Value);
            }

            Revenue = await revenueQuery.ToListAsync();
        }

    }
}

