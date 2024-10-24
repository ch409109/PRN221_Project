using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookingTicketOnline.Models
{
    public partial class MovieCategory
    {
        public MovieCategory()
        {
            Movies = new HashSet<Movie>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters")]
        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
