using System.ComponentModel.DataAnnotations;

namespace Audio_Junction.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required]
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }


    }
}
