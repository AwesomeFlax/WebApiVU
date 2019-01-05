using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiVU.Models.User
{
    public class CreateModel : BaseModel, IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Email.Contains("@") || string.IsNullOrEmpty(Email))
            {
                yield return new ValidationResult("Email must not empty and contain mail service reference (e.g. @gmail.com)", new[] { "Email" });
            }

            if (string.IsNullOrEmpty(Password) && Password.Length < 6)
            {
                yield return new ValidationResult("Password must not empty and more then 6 char length", new[] { "Password" });
            }

            if (!PasswordConfirm.Equals(Password))
            {
                yield return new ValidationResult("PasswordConfirm must be same value as 'Password'", new[] { "PasswordConfirm" });
            }

            if (string.IsNullOrEmpty(UserName))
            {
                yield return new ValidationResult("User name must not empty or NULL", new[] { "UserName" });
            }
        }
    }
}