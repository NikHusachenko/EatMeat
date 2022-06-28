using EatMeat.Database.Enums;
using FluentValidation;

namespace EatMeat.Services.MeatServices.Models
{
    public class CreateViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public float Weight { get; set; }
        public int Type { get; set; }
        public int Source { get; set; }
    }

    public class CreateValidator : AbstractValidator<CreateViewModel>
    {
        public CreateValidator()
        {
            RuleFor(x => x.Name).Length(3, 15).NotEmpty().NotNull();
            RuleFor(x => x.Description).Length(7, 511).NotEmpty().NotNull();
            RuleFor(x => x.Price).NotEmpty().NotNull();
            RuleFor(x => x.Source).NotEmpty().NotNull();
            RuleFor(x => x.Type).NotEmpty().NotNull();
            RuleFor(x => x.Weight).NotEmpty().NotNull();
        }
    }
}