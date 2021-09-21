using System;

namespace FleetManager.EFCore.Models
{
    public class ChauffeurVoertuig
    {
        public string Id { get; set; }

        public ReadTankaart Tankkaart { get; set; }

        public ReadChauffeur Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime? AfsluitDatum { get; set; }
    }
}
