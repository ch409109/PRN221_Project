using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Cinema
    {
        public Cinema()
        {
            Revenues = new HashSet<Revenue>();
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }
        public string? Location { get; set; }
        public string? City { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }

        public virtual ICollection<Revenue> Revenues { get; set; }
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
