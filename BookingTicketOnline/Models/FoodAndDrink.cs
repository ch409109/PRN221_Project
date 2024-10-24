using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingTicketOnline.Models
{
    public partial class FoodAndDrink
    {
        public FoodAndDrink()
        {
            BookingItems = new HashSet<BookingItem>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 1000")]
        public int Quantity { get; set; }

        [MaxLength(500, ErrorMessage = "Image path cannot be longer than 500 characters")]
        public string? Image { get; set; }

        public string? Status { get; set; }

        public virtual ICollection<BookingItem> BookingItems { get; set; }
    }
}
