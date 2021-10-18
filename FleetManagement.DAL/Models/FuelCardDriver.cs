using System;

namespace FleetManagement.Domain.Models
{
    public class FuelCardDriver : IBaseClass
    {
        public int Id { get; private set; }

        public FuelCard FuelCard { get; private set; }

        public Driver Driver { get; private set; }

        public bool Active { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime ClosureDate { get; private set; }
    }
}
