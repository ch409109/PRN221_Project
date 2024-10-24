using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Title is required")]
        [MaxLength(200, ErrorMessage = "Title cannot be longer than 200 characters")]
        public string Title { get; set; }

        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters")]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Release date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Url(ErrorMessage = "Invalid URL format")]
        public string TrailerUrl { get; set; }

        [Required(ErrorMessage = "Actors is required")]
        public string Actor { get; set; }

        [StringLength(150, ErrorMessage = "Director cannot be longer than 200 characters")]
        public string Director { get; set; }

        public string? Poster { get; set; }

        public string? Status { get; set; }

        public virtual MovieCategory? Category { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
