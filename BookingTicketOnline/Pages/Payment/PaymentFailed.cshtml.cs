using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookingTicketOnline.Pages.Payment
{
    public class PaymentFailedModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PaymentFailedModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGetTryAgain()
        {
            var showtimeId = _httpContextAccessor.HttpContext?.Session.GetInt32("ShowtimeId");
            if (!showtimeId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            return RedirectToPage("/Seat/BookSeat");
        }
    }
}
