using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookingTicketOnline.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BookingTicketOnline.Pages.News
{
    public class ListNewsModel : PageModel
    {
        private readonly PRN221_FinalProjectContext _context;

        public ListNewsModel(PRN221_FinalProjectContext context)
        {
            _context = context;
        }

        public List<Models.News> NewsList { get; set; }

        public string LimitWords(string content, int wordLimit)
        {
            if (string.IsNullOrEmpty(content)) return content;

            var words = content.Split(' ');
            if (words.Length <= wordLimit) return content;

            return string.Join(' ', words.Take(wordLimit)) + "...";
        }


        public async Task OnGetAsync()
        {
            NewsList = await _context.News.OrderByDescending(n => n.CreateAt).ToListAsync();
        }
    }
}

