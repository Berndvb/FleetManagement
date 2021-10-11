using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;
using FleetManagement.Framework.Helpers;

namespace FleetManagement.ReadAPI.Features.AppealManagement.GetAllAppeals
{
    public class GetAllAppealsQueryValidator : AbstractValidator<GetAllAppealsQuery>
    {
        public GetAllAppealsQueryValidator()
        {
            //RuleFor(x => x.AppealStatus).Must(y => y >= 0 && (int)y < 4);

            When(x => !String.IsNullOrEmpty(x.AppealStatus), () =>
           {
               RuleFor(x => x.AppealStatus)
                .Must(y => Enum.IsDefined(typeof(AppealStatus), y.CorrectStringInput()))
                .WithMessage("Please enter a valid appeal-status (new, open or closed).");
           });
        }
    }
}
