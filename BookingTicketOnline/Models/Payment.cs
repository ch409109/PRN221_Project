using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Revenues = new HashSet<Revenue>();
        }

        public int Id { get; set; }
        public int? BookingId { get; set; }
        public int? Amount { get; set; }
        public int? DiscountId { get; set; }

        public virtual Booking? Booking { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual ICollection<Revenue> Revenues { get; set; }
    }
}
