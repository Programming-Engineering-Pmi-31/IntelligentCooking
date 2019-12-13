using FluentValidation;
using InelligentCooking.BLL.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class ImageValidator: AbstractValidator<IFormFile>
    {
        public ImageValidator()
        {
            RuleFor(x => x)
                .Must(x => x.IsImage());

            RuleFor(x => x.Length)
                .LessThanOrEqualTo(5000000);
        }
    }
}
