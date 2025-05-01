using EmergencyAlert.Models;
using FluentValidation;

namespace EmergencyAlert.Validator
{
    public class EmergencyEventValidator : AbstractValidator<EmergencyEvent>
    {
        public EmergencyEventValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("needs title for sure");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("needs description")
                .MinimumLength(5).WithMessage("description cant be that short");

            RuleFor(x => x.Severity)
                .NotEmpty()
                .WithMessage("selerity cant be empty")
                .LessThanOrEqualTo(5)
                .GreaterThanOrEqualTo(1);
                

                
        }
    }
}
