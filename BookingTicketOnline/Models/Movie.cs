using System;
using System.Collections.Generic;

namespace BookingTicketOnline.Models
{
    public partial class Movie
    {
        public Movie()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
            Showtimes = new HashSet<Showtime>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? TrailerUrl { get; set; }
        public DateTime? ShowTime { get; set; }
        public string? Actor { get; set; }
        public string? Director { get; set; }
        public string? Poster { get; set; }
        public string? Status { get; set; }

        public virtual MovieCategory? Category { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
