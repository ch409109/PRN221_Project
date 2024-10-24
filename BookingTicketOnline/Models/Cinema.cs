using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingTicketOnline.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Bookings = new HashSet<Booking>();
            Rooms = new HashSet<Room>();
            Showtimes = new HashSet<Showtime>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [MaxLength(200, ErrorMessage = "Location cannot be longer than 200 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "City is required")]
        [MaxLength(60, ErrorMessage = "City cannot be longer than 100 characters")]
        public string City { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(200, ErrorMessage = "Name cannot be longer than 200 characters")]
        public string Name { get; set; }
        
        public string? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
