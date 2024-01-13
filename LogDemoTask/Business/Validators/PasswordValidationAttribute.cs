using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace LogDemoTask.Business.Validators
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;

            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            var isUppercase = new Regex(@"[A-Z]").IsMatch(password);
            var isNumber = new Regex(@"[0-9]").IsMatch(password);
            var isSymbol = new Regex(@"[!@#$%^&*()_+{}\[\]:;<>,.?~\\/-]").IsMatch(password);

            return password.Length >= 8 && isUppercase && isNumber && isSymbol;
        }
    }
}
