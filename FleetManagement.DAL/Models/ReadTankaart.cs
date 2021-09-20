using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.DAL.Models
{
    public class ReadTankaart
    {
        public string Kaartnummer { get; set; }

        public DateTime GeldigheidsDatum { get; set; }

        public string Pincode { get; set; }

        public EAuthenticatieType AuthenticatieType { get; set; }

        public TankkaartOpties TankkaartOpties { get; set; }

        public bool Geblokkeerd { get; set; }

        public List<TankkaartChauffeur> Chauffeurs { get; set; }
    }
}
