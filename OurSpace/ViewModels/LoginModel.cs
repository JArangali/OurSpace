using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OurSpace.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email must not be empty.")]
        [Display(Name = "Email")]
        public string? Uemail { get; set; }

        [Required(ErrorMessage = "Password must not be empty.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? UPassword { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
