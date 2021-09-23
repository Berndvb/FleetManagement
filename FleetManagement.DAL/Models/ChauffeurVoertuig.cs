using System;

namespace FleetManagement.Domain.Models
{
    public class ChauffeurVoertuig
    {
        public string Id { get; set; }

        public ReadVoertuig Voertuig { get; set; }

        public ReadChauffeur Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime? AfsluitDatum { get; set; }
    }
}
