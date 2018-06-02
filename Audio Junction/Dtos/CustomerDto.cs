using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Audio_Junction.Dtos
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Min18YrsIfAMember]
        public DateTime? BirthDate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        public byte MembershipTypeId { get; set; }
    }
}