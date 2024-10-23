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
        public string? SeatName { get; set; }
        public int? RowId { get; set; }
        public string? Status { get; set; }

        public virtual Row? Row { get; set; }
        public virtual ICollection<BookingSeatsDetail> BookingSeatsDetails { get; set; }
    }
}
