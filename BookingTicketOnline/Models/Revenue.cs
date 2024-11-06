using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Revenue
    {
        public int Id { get; set; }
        public int? PaymentId { get; set; }
        public int? TotalRevenue { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public virtual Payment? Payment { get; set; }
    }
}
