using UsersService.Core.DTO;
using FluentValidation;

namespace UsersService.Core.Validators
{
    public class RegistrationRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email is required.")
                .EmailAddress()
                .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")
                .MinimumLength(6)
                .WithMessage("Password must be at least 6 characters long.");

            RuleFor(x => x.PersonName).NotEmpty().WithMessage("Person name is required.");
            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Invalid gender option. Valid options are: Male, Female, Other.");
        }
    }
}
