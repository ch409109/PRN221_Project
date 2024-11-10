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
		public List<Models.Movie> Movies { get; set; }
		public List<Models.Room> Rooms { get; set; }

		[BindProperty(SupportsGet = true)]
		public bool isAutoRendered { get; set; }

		[BindProperty]
		public Models.Showtime Showtime { get; set; } = new Models.Showtime();
		public Models.Room? room { get; set; }
		public DateTime StartOfWeek { get; set; }



		public async Task OnGetAsync(int? weekOffset)
        {
            // Xác định tuần hiện tại hoặc tuần được điều hướng
            StartOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek);
            if (weekOffset.HasValue)
            {
                StartOfWeek = StartOfWeek.AddDays(weekOffset.Value * 7);
            }

            // Lấy các suất chiếu của tuần
            Showtimes = await _context.Showtimes
                .Include(s => s.Movie)
                .Include(s => s.Room)
                .Where(s => s.Date >= StartOfWeek && s.Date < StartOfWeek.AddDays(7))
                .ToListAsync();

            Movies = await _context.Movies.ToListAsync();
            Rooms = await _context.Rooms.ToListAsync();
        }
    }
}
