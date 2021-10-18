using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class FuelCard : IBaseClass
    {
        public int Id { get; private set; }

        public string CardNumber { get; private set; }

        public DateTime ExpirationDate { get; private set; }

        public string Pincode { get; private set; }

        public AuthenticationType AuthenticationType { get; private set; }

        public bool Blocked { get; private set; }

        public FuelCardOptions FuelCardOptions { get; private set; }

        public List<FuelCardDriver> FuelCardDrivers { get; private set; }

        public void ChangeFuelCardInfoForDriver(
            AuthenticationType authenticationType, 
            bool blocked, 
            string pincode)
        {
            AuthenticationType = authenticationType;
            Blocked = blocked;
            Pincode = pincode;
        }
    }
}
