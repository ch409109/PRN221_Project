using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public string? Code { get; set; }
        public decimal DiscountValue { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
