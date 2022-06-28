using FluentValidation;

namespace EatMeat.Services.UserServices.Models
{
    public class SignInViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }

    public class SignInValidator : AbstractValidator<SignInViewModel>
    {
        public SignInValidator()
        {
            RuleFor(x => x.Login).Length(3, 15).NotEmpty().NotNull();
            RuleFor(x => x.Password).Length(3, 15).NotEmpty().NotNull();
        }
    }
}