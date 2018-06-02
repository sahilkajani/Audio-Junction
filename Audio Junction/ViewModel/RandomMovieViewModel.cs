using Audio_Junction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audio_Junction.ViewModel
{
    public class RandomMovieViewModel
    {
       public Movie Movie { get; set; }

        public List<Customer> Customers { get; set; }
    }
}