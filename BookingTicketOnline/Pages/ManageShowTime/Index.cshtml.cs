using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookingTicketOnline.Models;

namespace BookingTicketOnline.Pages.ManageShowTime
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public IndexModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public List<Models.Showtime> Showtimes { get; set; }

        public async Task OnGetAsync()
        {

            Showtimes = await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Room)
                    .ThenInclude(r => r.Cinema)
                .ToListAsync();
        }

    }
}
