using LogDemoTask.Business.Validators;
using System.ComponentModel.DataAnnotations;

namespace LogDemoTask.Models
{
    public class User
    {
        [Required(ErrorMessage = "Custom Message")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "LoginId must contain only numeric characters")]
        public int LoginId { get; set; }
        
        [Required]
        [PasswordValidation(ErrorMessage = "Password must have at least one uppercase letter, minimum eight characters, at least one number, and one symbol")]
        public string Password { get; set; }
    }
}
