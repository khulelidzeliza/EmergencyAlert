using EmergencyAlert.Models;
using FluentValidation;

namespace EmergencyAlert.Validator
{
    public class UserValidator  : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("email cant be empty")
                .EmailAddress()
                .WithMessage("try correct email");

            //RuleFor(x => x.PhoneNumber)
            //    .NotEmpty()
            //    .WithMessage("Phone number is required.")
            //    .Matches(@"^\d{9}$")
            //    .WithMessage("Phone number must be exactly 9 digits.");

        }

    }
    }

