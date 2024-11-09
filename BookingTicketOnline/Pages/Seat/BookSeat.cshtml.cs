using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BookingTicketOnline.Pages.Seat
{
    public class BookSeatModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<BookSeatModel> _logger;

        public BookSeatModel(PRN221_FinalProjectContext context, IHttpContextAccessor httpContextAccessor, ILogger<BookSeatModel> logger)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        [BindProperty]
        public List<int> SelectedSeatIds { get; set; } = new();
        public List<Row> Rows { get; set; } = new();
        public Dictionary<int, string> SeatStatuses { get; set; } = new();
        public int TotalAmount { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var showtimeId = _httpContextAccessor.HttpContext?.Session.GetInt32("ShowtimeId");
            if (!showtimeId.HasValue)
            {
                return RedirectToPage("/Index");
            }

            // Get showtime and room information
            var showtime = await _context.Showtimes
                .Include(s => s.Room)
                    .ThenInclude(r => r.Rows)
                        .ThenInclude(r => r.Seats)
                .FirstOrDefaultAsync(s => s.Id == showtimeId);

            if (showtime == null)
            {
                return NotFound();
            }

            Rows = showtime.Room.Rows.OrderBy(r => r.RowName).ToList();

            // Get booked seats for this showtime
            var bookedSeats = await _context.BookingSeatsDetails
                .Include(bs => bs.Booking)
                .Where(bs => bs.Booking.ShowtimeId == showtimeId)
                .Select(bs => bs.SeatId)
                .ToListAsync();

            // Create dictionary of seat statuses
            SeatStatuses = Rows.SelectMany(r => r.Seats)
                .ToDictionary(
                    s => s.Id,
                    s => bookedSeats.Contains(s.Id) ? "Booked" : s.Status
                );

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!SelectedSeatIds.Any())
            {
                return Page();
            }

            var seats = await _context.Seats
                .Include(s => s.Row)
                .Where(s => SelectedSeatIds.Contains(s.Id))
                .ToListAsync();

            // Calculate total price
            int totalPrice = seats.Sum(s => s.Row.Type.ToLower() == "vip" ? 150000 : 120000);

            // Store selected seats and total price in session
            HttpContext.Session.SetString("SelectedSeatIds",
                JsonSerializer.Serialize(SelectedSeatIds));
            HttpContext.Session.SetInt32("SeatTotalAmount", totalPrice);

            // Add seat total to existing food total if any
            var foodTotal = HttpContext.Session.GetInt32("FoodTotalAmount") ?? 0;
            var finalTotal = totalPrice + foodTotal;
            HttpContext.Session.SetInt32("TotalPrice", finalTotal);

            return RedirectToPage("/Foods/BookFoods");
        }

        public JsonResult OnGetCalculateTotal([FromQuery] List<int> seatIds)
        {
            try
            {
                if (seatIds == null || !seatIds.Any())
                    return new JsonResult(new { total = 0 });

                // Log ?? debug
                _logger?.LogInformation($"Received seatIds: {string.Join(", ", seatIds)}");

                var seats = _context.Seats
                    .Include(s => s.Row)
                    .Where(s => seatIds.Contains(s.Id))
                    .ToList();

                // Log s? l??ng gh? tìm th?y
                _logger?.LogInformation($"Found {seats.Count} seats");

                int total = seats.Sum(s => s.Row.Type.ToLower() == "vip" ? 150000 : 120000);

                // Log t?ng ti?n
                _logger?.LogInformation($"Calculated total: {total}");

                return new JsonResult(new { total });
            }
            catch (Exception ex)
            {
                _logger?.LogError($"Error in OnGetCalculateTotal: {ex.Message}");
                return new JsonResult(new { error = ex.Message });
            }
        }
    }
}
