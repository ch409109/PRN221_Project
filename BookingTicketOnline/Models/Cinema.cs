using System;
using System.Collections.Generic;

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
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
