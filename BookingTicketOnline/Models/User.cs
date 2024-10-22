using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTicketOnline.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            Feedbacks = new HashSet<Feedback>();
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public int? RoleId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(50, ErrorMessage = "Username cannot be longer than 50 characters.")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long and cannot be longer than 100 characters.")]
        public string Password { get; set; } = null!;

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format.")]
        public string? PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of birth is required.")]
        public DateTime? Dob { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot be longer than 100 characters.")]
        public string? FullName { get; set; }
      
        public string? Status { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<News> News { get; set; }

		[NotMapped]
		public bool RememberMe { get; set; }
    }
}
