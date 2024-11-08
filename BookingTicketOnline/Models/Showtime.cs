using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Showtime
    {
        public Showtime()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public int? MovieId { get; set; }
        public int? RoomId { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? Date { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
