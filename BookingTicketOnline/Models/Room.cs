using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Room
    {
        public Room()
        {
            Seats = new HashSet<Seat>();
            Showtimes = new HashSet<Showtime>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CinemaId { get; set; }
        public int? Rows { get; set; }
        public int? Columns { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
