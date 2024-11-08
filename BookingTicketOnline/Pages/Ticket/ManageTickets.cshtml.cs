using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.Ticket
{
    public class ManageTicketsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        public ManageTicketsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }
        [BindProperty]
        public string SearchTerm { get; set; }
        public string Msg { get; set; }
        [BindProperty]
        public Models.Booking booking { get; set; }
        public void OnGet()
        {
        }
		public async Task OnPostSearchAsync()
		{
			booking = await _context.Bookings
			.Include(b => b.User)
			.Include(b => b.Movie)
			.Include(b => b.Cinema)
				.ThenInclude(c => c.Showtimes)
			.Include(b => b.BookingSeatsDetails)
				.ThenInclude(bsd => bsd.Seat)
			.Include(b => b.BookingItems)
				.ThenInclude(bi => bi.FoodAndDrinks)
			.FirstOrDefaultAsync(b => SearchTerm.Equals(b.TicketCode));
			if (booking == null)
			{
				Msg = $"Ticket code \"{SearchTerm}\" does not exist.";
			}
			else
			{
				return;
			}

		}
		public async Task OnPostConfirmAsync(int id)
		{
			var confirmedBooking = await _context.Bookings.FindAsync(id);
			if (confirmedBooking != null)
			{
				confirmedBooking.Status = "Confirmed";
                _context.Bookings.Update(confirmedBooking);
                await _context.SaveChangesAsync();
				Msg = $"Ticket code \"{SearchTerm}\" has already confirmed.";
			}
			

		}
	}
}
