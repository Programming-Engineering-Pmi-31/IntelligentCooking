using FluentValidation;
using InelligentCooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class AddIngredientValidator : AbstractValidator<AddIngredientDto>
    {
        AddIngredientValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();
        }
    }
}
