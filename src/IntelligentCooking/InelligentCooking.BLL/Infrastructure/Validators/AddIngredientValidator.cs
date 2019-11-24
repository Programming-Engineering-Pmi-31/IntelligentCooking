using FluentValidation;
using InelligentCooking.BLL.DTOs;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class AddIngredientValidator : AbstractValidator<AddIngredientDto>
    {
        public AddIngredientValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
