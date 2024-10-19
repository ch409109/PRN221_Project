using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Booking
    {
        public Booking()
        {
            BookingItems = new HashSet<BookingItem>();
            BookingSeatsDetails = new HashSet<BookingSeatsDetail>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public DateTime? BookingDate { get; set; }
        public int? CinemaId { get; set; }
        public int? MovieId { get; set; }
        public int? UserId { get; set; }
        public string? Status { get; set; }
        public decimal? TotalPrice { get; set; }

        public virtual Cinema? Cinema { get; set; }
        public virtual Movie? Movie { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<BookingItem> BookingItems { get; set; }
        public virtual ICollection<BookingSeatsDetail> BookingSeatsDetails { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
