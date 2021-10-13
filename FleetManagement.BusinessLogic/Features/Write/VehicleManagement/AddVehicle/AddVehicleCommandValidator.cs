using FleetManagement.Framework.Models.Enums;
using FluentValidation;
using System;

namespace FleetManagement.BLL.Features.Write.VehicleManagement.AddVehicle
{
    public class AddVehicleCommandValidator : AbstractValidator<AddVehicleCommand>
    {
        public AddVehicleCommandValidator()
        {
            RuleFor(x => x.Vehicle.Identity).NotNull();

            RuleFor(x => x.Vehicle.Identity.FuelType).Must(y => Enum.IsDefined(typeof(FuelType), y));

            RuleFor(x => x.Vehicle.Mileage).GreaterThan(0);
        }
    }
}
