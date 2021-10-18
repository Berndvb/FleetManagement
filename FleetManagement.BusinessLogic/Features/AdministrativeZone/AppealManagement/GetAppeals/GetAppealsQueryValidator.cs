using System;
using FleetManagement.Framework.Helpers;
using FleetManagement.Framework.Models.Enums;
using FluentValidation;

namespace FleetManagement.BLL.Features.AdministrativeZone.AppealManagement.GetAppeals
{
    public class GetAppealsQueryValidator : AbstractValidator<GetAppealsQuery>
    {
        public GetAppealsQueryValidator()
        {
            //RuleFor(x => x.AppealStatus).Must(y => y >= 0 && (int)y < 4);

            When(x => !String.IsNullOrEmpty(x.AppealStatus), () =>
           {
               RuleFor(x => x.AppealStatus)
                .Must(y => Enum.IsDefined(typeof(AppealStatus), y.CorrectStringInput()))
                .WithMessage("Please enter a valid appeal-status (new, open or closed).");
           });

            When(x => x.PagingParameters != null, () => {
                RuleFor(x => x.PagingParameters.PageSize).GreaterThan(0);
                RuleFor(x => x.PagingParameters.PageNumber).GreaterThan(0);
            });
        }
    }
}
