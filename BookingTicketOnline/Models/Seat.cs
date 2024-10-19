using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Seat
    {
        public Seat()
        {
            BookingSeatsDetails = new HashSet<BookingSeatsDetail>();
        }

        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? Row { get; set; }
        public int? Column { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }

        public virtual Room? Room { get; set; }
        public virtual ICollection<BookingSeatsDetail> BookingSeatsDetails { get; set; }
    }
}
