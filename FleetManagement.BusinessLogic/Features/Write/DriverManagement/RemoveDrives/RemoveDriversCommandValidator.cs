using FluentValidation;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDrives
{
    public class RemoveDriversCommandValidator : AbstractValidator<RemoveDrivesCommand>
    {
        public RemoveDriversCommandValidator()
        {
            RuleFor(x => x.Driver.Id)
                .Must(y => y > 0);
        }
    }
}
