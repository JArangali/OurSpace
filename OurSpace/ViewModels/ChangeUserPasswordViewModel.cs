
using System.ComponentModel.DataAnnotations;
namespace OurSpace.ViewModels
{
    public class ChangeUserPasswordViewModel
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email must not be empty.")]
        [Display(Name = "Email")]
        public string? Uemail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Admin Code")]
        [StringLength(10)]
        public string AdminCode { get; set; }
        
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
