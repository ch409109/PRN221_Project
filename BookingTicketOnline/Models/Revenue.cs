using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Revenue
    {
		public int Id { get; set; }
		public int? CinemaId { get; set; }
		public int? TotalRevenue { get; set; }
		public int? Quarters { get; set; }
		public int? Years { get; set; }
		public virtual Cinema? Cinema { get; set; }
	}
}
