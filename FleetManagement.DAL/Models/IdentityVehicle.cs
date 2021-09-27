using FleetManagement.Framework.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class IdentityVehicle
    {
        public int Id { get; set; }

        public string Chassisnumber { get; set; }

        public EFuelType FuelType { get; set; }

        public ECarType CarType { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string LicensePlates { get; set; }
    }
}
