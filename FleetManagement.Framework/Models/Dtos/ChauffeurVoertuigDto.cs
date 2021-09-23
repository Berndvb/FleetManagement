using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ChauffeurVoertuigDto
    {
        public string Id { get; set; }

        public VoertuigDto Voertuig { get; set; }

        public ChauffeurDto Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime? AfsluitDatum { get; set; }

        public ChauffeurVoertuigDto(
            string id,
            VoertuigDto voertuig,
            ChauffeurDto chauffeur,
            bool actief,
            DateTime aanmaakDatum,
            DateTime? afsluitDatum)
        {
            Id = id;
            Voertuig = voertuig;
            Chauffeur = chauffeur;
            Actief = actief;
            AanmaakDatum = aanmaakDatum;
            AfsluitDatum = afsluitDatum;
        }
    }
}
