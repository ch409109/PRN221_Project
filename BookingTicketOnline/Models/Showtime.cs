using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Showtime
    {
        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? CinemaId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? Showtime1 { get; set; }
        public DateTime? Date { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual Room? Room { get; set; }
    }
}
