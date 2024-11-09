using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

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

        public async Task<Booking> ProcessBookingAsync(int? totalPrice, List<(int FoodAndDrinkId, int Quantity)> selectedItems, int? discountId = null)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var showtimeId = _httpContextAccessor.HttpContext.Session.GetInt32("ShowtimeId");
                var userIdClaim = _httpContextAccessor.HttpContext?.User.FindFirst("UserId");
                if (userIdClaim == null)
                {
                    throw new UnauthorizedAccessException("User not authorized.");
                }
                int userId = int.Parse(userIdClaim.Value);

                var booking = new Booking
                {
                    UserId = userId,
                    TicketCode = GenerateTicketCode(),
                    BookingDate = DateTime.Now,
                    Status = "Pending",
                    TotalPrice = totalPrice,
                    ShowtimeId = showtimeId
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                var selectedSeatIdsJson = _httpContextAccessor.HttpContext.Session.GetString("SelectedSeatIds");
                if (!string.IsNullOrEmpty(selectedSeatIdsJson))
                {
                    var selectedSeatIds = JsonSerializer.Deserialize<List<int>>(selectedSeatIdsJson);
                    var seats = await _context.Seats
                        .Include(s => s.Row)
                        .Where(s => selectedSeatIds.Contains(s.Id))
                        .ToListAsync();

                    foreach (var seat in seats)
                    {
                        var bookingSeat = new BookingSeatsDetail
                        {
                            BookingId = booking.Id,
                            SeatId = seat.Id,
                            Price = seat.Row.Type.ToLower() == "vip" ? 150000 : 120000
                        };
                        _context.BookingSeatsDetails.Add(bookingSeat);
                    }
                }

                foreach (var (foodAndDrinkId, quantity) in selectedItems)
                {
                    var foodItem = await _context.FoodAndDrinks.FindAsync(foodAndDrinkId);
                    if (foodItem != null && foodItem.Quantity >= quantity)
                    {
                        var bookingItem = new BookingItem
                        {
                            BookingId = booking.Id,
                            FoodAndDrinksId = foodAndDrinkId,
                            Quantity = quantity,
                            Price = foodItem.Price * quantity
                        };

                        _context.BookingItems.Add(bookingItem);
                        foodItem.Quantity -= quantity;
                    }
                    else
                    {
                        throw new InvalidOperationException($"Insufficient quantity for food item {foodItem?.Name}");
                    }
                }

                var payment = new Payment
                {
                    BookingId = booking.Id,
                    Amount = totalPrice,
                    DiscountId = discountId
                };

                _context.Payments.Add(payment);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return booking;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        private string GenerateTicketCode()
        {
            var random = new Random();
            return $"{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{random.Next(100000, 999999)}";
        }
    }
}
