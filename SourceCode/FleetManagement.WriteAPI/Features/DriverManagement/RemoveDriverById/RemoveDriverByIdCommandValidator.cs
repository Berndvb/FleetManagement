using FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriver;
using FluentValidation;

namespace FleetManagement.WriteAPI.Features.DriverManagement.RemoveDriverById
{
    public class RemoveDriverByIdCommandValidator : AbstractValidator<RemoveDriverByIdCommand>
    {
        public RemoveDriverByIdCommandValidator()
        {

        }
    }
}
