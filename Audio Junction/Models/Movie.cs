using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Audio_Junction.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        [Display(Name = "Number In Stock")]
        public int NumberInStock { get; set; }


        [Required]
        [Range(1, 20)]
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre Id")]
        public byte GenreId { get; set; }

    }
}