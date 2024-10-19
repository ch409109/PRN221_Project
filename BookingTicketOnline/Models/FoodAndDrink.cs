using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class FoodAndDrink
    {
        public FoodAndDrink()
        {
            BookingItems = new HashSet<BookingItem>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }

        public virtual ICollection<BookingItem> BookingItems { get; set; }
    }
}
