using Audio_Junction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audio_Junction.ViewModel
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre> Genre { get; set; }
        public string Title
        {
            get
            {
                if (Movie != null && Movie.ID != 0)
                    return "Edit Movie";


                return "New Movie";
            }
        }
    }
}