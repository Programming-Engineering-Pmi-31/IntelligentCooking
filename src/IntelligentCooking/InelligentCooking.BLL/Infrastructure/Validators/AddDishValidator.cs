using System.Linq;
using FluentValidation;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Extensions;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class AddDishValidator : AbstractValidator<AddDishDto>
    {
        public AddDishValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Recipe)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Servings)
                .GreaterThanOrEqualTo(x => 1);

            RuleFor(x => x.Proteins)
                .GreaterThanOrEqualTo(x => 0);

            RuleFor(x => x.Fats)
                .GreaterThanOrEqualTo(x => 0);

            RuleFor(x => x.Carbohydrates)
                .GreaterThanOrEqualTo(x => 0);

            RuleFor(x => x.Calories)
                .GreaterThanOrEqualTo(x => 0);

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Images)
                .Must(x => x.IsImage());

            RuleFor(x => x.IngredientAmounts)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Time)
                .Matches(Constants.Constants.TimeRegExp);

            RuleForEach(x => x.Images)
                .SetValidator(new ImageValidator());

            RuleFor(x => x.Ingredients)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Must((f, x) => f.IngredientAmounts.Count() == x.Count())
                .WithMessage(
                    Constants.Constants.CollectionsOfSameLengthErrorMessage(
                        nameof(AddDishDto.Ingredients),
                        nameof(AddDishDto.IngredientAmounts)))
                .ForEach(x => x.GreaterThanOrEqualTo(0));

            RuleFor(x => x.Categories)
                .NotNull()
                .NotEmpty()
                .ForEach(x => x.GreaterThanOrEqualTo(0));
        }
    }
}
