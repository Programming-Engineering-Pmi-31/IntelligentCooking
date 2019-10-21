using FluentValidation;
using InelligentCooking.BLL.DTOs;
using InelligentCooking.BLL.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class AddDishValidator: AbstractValidator<AddDishDto>
    {
        public AddDishValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty();

            RuleForEach(x => x.Images)
                .Must(x => x.IsImage());
        }
    }
}
