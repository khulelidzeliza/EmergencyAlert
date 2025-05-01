using EmergencyAlert.Models;
using FluentValidation;

namespace EmergencyAlert.Validator
{
    public class VolunteerValidator :AbstractValidator<Volunteer>
    {
        public VolunteerValidator()
        {
            RuleFor(x => x.Skills)
                .NotEmpty()
                .WithMessage("u need to have skills to be volunteer");

           
        }
    }
}
