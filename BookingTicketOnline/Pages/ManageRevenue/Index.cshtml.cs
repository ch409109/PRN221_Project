using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookingTicketOnline.Pages.ManagerRevenue
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public IndexModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Revenue> Revenue { get; set; } = default!;
        public SelectList CinemaList { get; set; } = default!;
        public SelectList YearList { get; set; } = default!;
        public SelectList MonthList { get; set; } = default!;
        public List<MonthlyRevenue> MonthlyRevenueData { get; set; } = new List<MonthlyRevenue>();
        public List<MovieSales> TopSellingMovies { get; set; } = new List<MovieSales>();

        [BindProperty(SupportsGet = true)]
        public int? SelectedCinemaId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedYear { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedMonth { get; set; }
        public async Task OnGetAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            // Load Cinema and Year data for dropdowns
            CinemaList = new SelectList(await _context.Cinemas.ToListAsync(), "Id", "Name");
            YearList = new SelectList(await _context.Bookings
                                                   .Where(b => b.BookingDate.HasValue)
                                                   .Select(b => b.BookingDate.Value.Year)
                                                   .Distinct()
                                                   .ToListAsync());
            MonthList = new SelectList(Enumerable.Range(1, 12).Select(i => new { Value = i, Text = $"Tháng {i}" }), "Value", "Text");

            // Monthly revenue data for selected cinema and year
            if (SelectedCinemaId.HasValue && SelectedYear.HasValue)
            {
                // Generate data for all months
                MonthlyRevenueData = Enumerable.Range(1, 12).Select(month => new MonthlyRevenue
                {
                    Month = month,
                    TotalRevenue = 0
                }).ToList();

                var revenueData = await _context.Bookings
                    .Where(b => b.Showtime.Room.CinemaId == SelectedCinemaId && b.BookingDate.Value.Year == SelectedYear)
                    .GroupBy(b => b.BookingDate.Value.Month)
                    .Select(g => new MonthlyRevenue
                    {
                        Month = g.Key,
                        TotalRevenue = g.Sum(b => b.TotalPrice.Value)
                    })
                    .ToListAsync();

                // Update months with revenue data
                foreach (var data in revenueData)
                {
                    MonthlyRevenueData.First(m => m.Month == data.Month).TotalRevenue = data.TotalRevenue;
                }

                // Get all movies for the selected cinema and year, including those with zero ticket sales
                var moviesInCinema = await _context.Movies
                    .Where(m => m.Showtimes.Any(s => s.Room.CinemaId == SelectedCinemaId))
                    .Select(m => m.Title)
                    .ToListAsync();

                var movieSalesData = await _context.Bookings
             .Where(b => b.Showtime.Room.CinemaId == SelectedCinemaId && b.BookingDate.Value.Year == SelectedYear)
             .GroupBy(b => b.Showtime.Movie.Title)
             .Select(g => new MovieSales
             {
                 MovieTitle = g.Key,
                 TotalRevenue = g.Sum(b => b.TotalPrice.Value),
                 TicketsSold = g.Count()
             })
             .ToDictionaryAsync(ms => ms.MovieTitle);

                // Populate TopSellingMovies with all movies, including those with zero sales
                TopSellingMovies = moviesInCinema.Select(movieTitle => new MovieSales
                {
                    MovieTitle = movieTitle,
                    TotalRevenue = movieSalesData.ContainsKey(movieTitle) ? movieSalesData[movieTitle].TotalRevenue : 0,
                    TicketsSold = movieSalesData.ContainsKey(movieTitle) ? movieSalesData[movieTitle].TicketsSold : 0
                })
                .OrderByDescending(m => m.TicketsSold)
                .Take(10)
                .ToList();
            }
        }


        public class MonthlyRevenue
        {
            public int Month { get; set; }
            public decimal TotalRevenue { get; set; }
        }

        public class MovieSales
        {
            public string? MovieTitle { get; set; }
            public decimal TotalRevenue { get; set; }
            public int TicketsSold { get; set; }
        }
        // Method to export Excel
        public async Task<IActionResult> OnPostExportToExcelAsync()
        {
            if (SelectedCinemaId.HasValue && SelectedYear.HasValue)
            {
                var cinema = await _context.Cinemas.FindAsync(SelectedCinemaId);
                var cinemaName = cinema?.Name ?? "Không xác định";

                // Format title with cinema name, month, and year
                var title = $"DoanhThu_{cinemaName}_{(SelectedMonth.HasValue ? $"Tháng_{SelectedMonth.Value}_" : "")}{SelectedYear}.xlsx";

                var bookings = _context.Bookings
                   .Include(b => b.User)
                   .Include(b => b.Showtime)
                   .ThenInclude(s => s.Movie)
                   .Include(b => b.Showtime)
                   .ThenInclude(s => s.Room)
                   .ThenInclude(r => r.Cinema)
                   .Where(b => b.Showtime.Room.CinemaId == SelectedCinemaId && b.BookingDate.Value.Year == SelectedYear);

                if (SelectedMonth.HasValue)
                {
                    bookings = bookings.Where(b => b.BookingDate.Value.Month == SelectedMonth);
                }

                var package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("Bookings");

                // Đặt tiêu đề cho các cột
                worksheet.Cells[1, 1].Value = "Họ và tên";
                worksheet.Cells[1, 2].Value = "Số điện thoại";
                worksheet.Cells[1, 3].Value = "Tên phim";
                worksheet.Cells[1, 4].Value = "Phòng chiếu";
                worksheet.Cells[1, 5].Value = "Ngày xem";
                worksheet.Cells[1, 6].Value = "Thời gian";
                worksheet.Cells[1, 7].Value = "Địa điểm";
                worksheet.Cells[1, 8].Value = "Số tiền thanh toán";

                using (var range = worksheet.Cells[1, 1, 1, 8])
                {
                    range.Style.Font.Bold = true;
                }

                // Xuất dữ liệu
                var row = 2;
                foreach (var booking in bookings)
                {
                    worksheet.Cells[row, 1].Value = booking.User?.FullName ?? "Không xác định";
                    worksheet.Cells[row, 2].Value = booking.User?.PhoneNumber ?? "Không xác định";
                    worksheet.Cells[row, 3].Value = booking.Showtime?.Movie?.Title ?? "Không xác định";
                    worksheet.Cells[row, 4].Value = booking.Showtime?.Room?.Name ?? "Không xác định";

                    // Ngày xem
                    worksheet.Cells[row, 5].Value = booking.Showtime?.Date?.ToString("dd/MM/yyyy") ?? "Không xác định";

                    // Thời gian (kết hợp thời gian bắt đầu và kết thúc)
                    if (booking.Showtime?.StartTime.HasValue == true && booking.Showtime?.EndTime.HasValue == true)
                    {
                        worksheet.Cells[row, 6].Value = $"{booking.Showtime.StartTime.Value:hh\\:mm} - {booking.Showtime.EndTime.Value:hh\\:mm}";
                    }
                    else
                    {
                        worksheet.Cells[row, 6].Value = "Không xác định";
                    }

                    worksheet.Cells[row, 7].Value = booking.Showtime?.Room?.Cinema?.Name ?? "Không xác định";
                    worksheet.Cells[row, 8].Value = booking.TotalPrice?.ToString("N0") ?? "0";
                    row++;
                }

                // Thêm tổng tiền ở dưới cùng
                var totalRevenue = bookings.Sum(b => b.TotalPrice ?? 0);
                worksheet.Cells[row, 7].Value = "Tổng tiền";
                worksheet.Cells[row, 8].Value = totalRevenue.ToString("N0");
                worksheet.Cells[row, 7, row, 8].Style.Font.Bold = true;

                return File(package.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", title);
            }

            TempData["error"] = "Vui lòng chọn rạp chiếu hoặc thời gian để xuất file";
            return Page();
        }


    }
}