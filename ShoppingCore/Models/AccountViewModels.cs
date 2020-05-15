using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCore.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        //[StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        public string UserEmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[StringLength(100, ErrorMessage = "Minimum {2} characters", MinimumLength = 2)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public int UserType { get; set; }
    }

    public class RegisterViewModel
    {

        [Required(ErrorMessage = "First name is required")]
        [StringLength(100, ErrorMessage = "Minimum {2} characters", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(100, ErrorMessage = "Minimum {2} characters", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        //[StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        [Remote("CheckEmailExist", "Account", ErrorMessage= "Email address is already used")]
        
        public string UserEmailId { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Minimum {2} characters", MinimumLength = 5)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }

        //[Required]
        [Display(Name = "User type")]
        public int UserType { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        public string EmailId { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Minimum {2} and Maximum {1} characters are allowed", MinimumLength = 5)]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "Password doesn't match")]
        public string ConfirmPassword { get; set; }
    }
}
