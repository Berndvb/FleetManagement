using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FuelCardDriverDto
    {
        public int Id { get; set; }

        public bool Active { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ClosureDate { get; set; }

        public FuelCardDriverDto(
            int id,
            bool active,
            DateTime creationDate,
            DateTime closureDate)
        {
            Id = id;
            Active = active;
            CreationDate = creationDate;
            ClosureDate = closureDate;
        }
        public FuelCardDriverDto()
        {
        }
    }
}
