using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? MovieId { get; set; }
        public string? Comments { get; set; }
        public DateTime? CreateAt { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual User? User { get; set; }
    }
}
