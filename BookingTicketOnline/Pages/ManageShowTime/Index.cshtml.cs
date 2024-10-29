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
        private readonly BookingTicketOnline.Models.PRN221_FinalProjectContext _context;

        public IndexModel(BookingTicketOnline.Models.PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Showtime> Showtime { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Showtimes != null)
            {
                Showtime = await _context.Showtimes
                .Include(s => s.Cinema)
                .Include(s => s.Movie)
                .Include(s => s.Room).ToListAsync();
            }
        }
    }
}
