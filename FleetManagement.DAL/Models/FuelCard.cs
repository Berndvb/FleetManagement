using FleetManagement.Domain.Interfaces.Models;
using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class FuelCard : IBaseClass
    {
        public int Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Pincode { get; set; }

        public AuthenticatieType AuthenticationType { get; set; }

        public FuelCardOptions FuelCardOptions { get; set; }

        public bool Blocked { get; set; }

        public List<FuelCardDriver> Drivers { get; set; }
    }
}
