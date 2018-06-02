using Audio_Junction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Audio_Junction.ViewModel
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}