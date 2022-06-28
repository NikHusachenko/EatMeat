using FluentValidation;

namespace EatMeat.Services.UserServices.Models
{
    public class SignUpViewModel
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class SignUpValidator : AbstractValidator<SignUpViewModel>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.Email).MaximumLength(31).EmailAddress().NotNull().NotEmpty();
            RuleFor(x => x.Login).Length(3, 15).NotNull().NotEmpty();
            RuleFor(x => x.Password).Length(3, 15).NotNull().NotEmpty();
        }
    }
}