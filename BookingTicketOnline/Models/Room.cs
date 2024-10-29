using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Room
    {
        public Room()
        {
            Rows = new HashSet<Row>();
            Showtimes = new HashSet<Showtime>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? CinemaId { get; set; }
        public int? NumberOfRows { get; set; }
        public int? NumberOfColumns { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual ICollection<Row> Rows { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
