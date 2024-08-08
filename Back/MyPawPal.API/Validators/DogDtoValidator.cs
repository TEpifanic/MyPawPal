using FluentValidation;
using MyPawPal.Application.DTOs;

namespace MyPawPal.API.Validators
{
    public class DogDtoValidator : AbstractValidator<DogDto>
    {
        public DogDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Race).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Age).GreaterThan(0);
        }
    }
}
