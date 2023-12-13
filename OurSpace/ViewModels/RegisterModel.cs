using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OurSpace.ViewModels
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Admin Code is required. Contact your manager.")]
        [Display(Name = "Admin Code")]
        [DataType(DataType.Password)]
        [StringLength(5)]
        public string? AdminCode { get; set; }

        [Required(ErrorMessage = "First Name is required.")]
        [Display(Name = "First Name")]
        public string? UFname { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        public string? ULname { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string? Uemail { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [Display(Name = "Password")]
        public string? UPassword { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Display(Name = "Password")]
        [Compare("UPassword", ErrorMessage = "Passwords do not match." )]
        public string? UCPassword { get; set; }
    }
}
