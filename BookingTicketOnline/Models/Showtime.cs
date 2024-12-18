﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingTicketOnline.Models
{
    public partial class Showtime
    {
        public Showtime()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please select a movie.")]
        public int? MovieId { get; set; }
        public int? RoomId { get; set; }

		[Required(ErrorMessage = "Thởi gian bắt đầu bộ phim chưa được thêm")]
		public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public DateTime? Date { get; set; }

        public virtual Movie? Movie { get; set; }
        public virtual Room? Room { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
