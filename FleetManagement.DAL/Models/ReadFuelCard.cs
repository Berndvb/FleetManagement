using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class ReadFuelCard
    {
        public string Id { get; set; }

        public string CardNumber { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Pincode { get; set; }

        public EAuthenticatieType AuthenticationType { get; set; }

        public FuelCardOptions FuelCardOptions { get; set; }

        public bool Blocked { get; set; }

        public List<FuelCardDriver> Drivers { get; set; }
    }
}
