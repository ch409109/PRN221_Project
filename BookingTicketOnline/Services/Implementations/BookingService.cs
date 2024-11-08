using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingTicketOnline.Services.Implementations
{
    public class BookingService
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookingService(PRN221_FinalProjectContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> ProcessBookingAsync(int? cinemaId, int? movieId, List<(int FoodAndDrinkId, int Quantity)>? selectedItems, int? discountId = null)
        {
            var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");

            if (userIdClaim == null)
            {
                return new UnauthorizedResult();
            }
            int userId = int.Parse(userIdClaim.Value);

            var random = new Random();
            string ticketCode = $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{random.Next(100000, 999999)}";

            var booking = new Booking
            {
                UserId = userId,
                //CinemaId = cinemaId,
                //MovieId = movieId,
                TicketCode = ticketCode,
                BookingDate = DateTime.Now,
                Status = "Unused",
                TotalPrice = _httpContextAccessor.HttpContext.Session.GetInt32("TotalPrice")
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            foreach (var item in selectedItems)
            {
                var foodItem = await _context.FoodAndDrinks.FindAsync(item.FoodAndDrinkId);

                if (foodItem != null)
                {
                    var totalItemPrice = foodItem.Price * item.Quantity;

                    var bookingItem = new BookingItem
                    {
                        BookingId = booking.Id,
                        FoodAndDrinksId = item.FoodAndDrinkId,
                        Quantity = item.Quantity,
                        Price = totalItemPrice
                    };

                    _context.BookingItems.Add(bookingItem);

                    foodItem.Quantity -= item.Quantity;
                }
            }

            if (discountId.HasValue)
            {
                var payment = new Payment
                {
                    BookingId = booking.Id,
                    Amount = booking.TotalPrice,
                    DiscountId = discountId
                };

                _context.Payments.Add(payment);
            }

            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}
