using System;

namespace FleetManagement.Domain.Models
{
    public class TankkaartChauffeur
    {
        public string Id { get; set; }

        public ReadTankaart Tankkaart { get; set; }

        public ReadChauffeur Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime AfsluitDatum { get; set; }
    }
}
