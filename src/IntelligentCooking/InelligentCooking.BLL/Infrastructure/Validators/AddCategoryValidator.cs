using FluentValidation;
using InelligentCooking.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class AddCategoryValidator: AbstractValidator<AddCategoryDto>
    {
        public AddCategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Image)
                .SetValidator(new ImageValidator());
        }
    }
}
