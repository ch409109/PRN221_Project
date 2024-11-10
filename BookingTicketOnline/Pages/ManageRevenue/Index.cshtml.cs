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
        private readonly PRN221_FinalProjectContext _context;

        public IndexModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public IList<Revenue> Revenue { get; set; } = default!;
        public SelectList CinemaList { get; set; } = default!;
        public SelectList YearList { get; set; } = default!;
        public List<MonthlyRevenue> MonthlyRevenueData { get; set; } = new List<MonthlyRevenue>();
        public List<MovieSales> TopSellingMovies { get; set; } = new List<MovieSales>();

        [BindProperty(SupportsGet = true)]
        public int? SelectedCinemaId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? SelectedYear { get; set; }

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
    }
}
