using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Audio_Junction.Models
{
    public class Genre
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}