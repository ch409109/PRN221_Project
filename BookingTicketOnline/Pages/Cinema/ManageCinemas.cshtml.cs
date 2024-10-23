using BookingTicketOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingTicketOnline.Pages.Cinema
{
    public class ManageCinemasModel : PageModel
    {
        public List<Models.Cinema> cinemas = new List<Models.Cinema>();
        private readonly PRN221_FinalProjectContext _context;

        [BindProperty(SupportsGet = true)]
        public string CurrentFilter { get; set; }

        public int PageSize { get; set; } = 5;
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public ManageCinemasModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public async Task OnGetAsync(string searchString, int pageNumber = 1)
        {
            var totalItems = await _context.Cinemas.CountAsync();

            TotalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            CurrentPage = pageNumber;

            if (searchString != null)
            {
                CurrentFilter = searchString;
            }

            IQueryable<Models.Cinema> cinemasQuery = _context.Cinemas;

            if (!string.IsNullOrEmpty(CurrentFilter))
            {
                cinemasQuery = cinemasQuery.Where(c =>
                    c.Name.Contains(CurrentFilter));
            }

            cinemas = await cinemasQuery
                .OrderBy(c => c.Name)
                .Skip((CurrentPage - 1) * PageSize) // Bỏ qua các mục của các trang trước
                .Take(PageSize)                     // Lấy số mục cho trang hiện tại
                .ToListAsync();
        }
    }
}
