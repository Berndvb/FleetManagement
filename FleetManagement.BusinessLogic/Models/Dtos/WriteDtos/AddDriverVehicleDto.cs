using System;

namespace FleetManagement.BLL.Models.Dtos.WriteDtos

{
    public class AddDriverVehicleDto
    {

        public AddVehicleDetailsDto Vehicle { get; set; }

        public AddDriverDetailsDto Driver { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? ClosureDate { get; set; }
    }
}
