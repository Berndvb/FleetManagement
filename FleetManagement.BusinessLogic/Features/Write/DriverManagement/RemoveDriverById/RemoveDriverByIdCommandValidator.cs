using FluentValidation;

namespace FleetManagement.BLL.Features.Write.DriverManagement.RemoveDriverById
{
    public class RemoveDriverByIdCommandValidator : AbstractValidator<RemoveDriverByIdCommand>
    {
        public RemoveDriverByIdCommandValidator()
        {
            RuleFor(x => x.DriverId).GreaterThan(0);
        }
    }
}
