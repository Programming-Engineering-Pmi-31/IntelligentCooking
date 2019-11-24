using FluentValidation;
using IntelligentCooking.Web.Models.RequestModels;

namespace InelligentCooking.BLL.Infrastructure.Validators
{
    public class GetDishRequestValidator : AbstractValidator<GetDishRequest>
    {
        public GetDishRequestValidator()
        {
            RuleFor(x => x.Skip)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Take)
                .GreaterThanOrEqualTo(0);
        }
    }
}
