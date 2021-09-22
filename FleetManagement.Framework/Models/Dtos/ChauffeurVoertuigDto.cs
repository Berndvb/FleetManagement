using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ChauffeurVoertuigDto
    {
        public string Id { get; set; }

        public TankkaartDto Tankkaart { get; set; }

        public ChauffeurDto Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime? AfsluitDatum { get; set; }

        public ChauffeurVoertuigDto(
            string id,
            TankkaartDto tankkaart,
            ChauffeurDto chauffeur,
            bool actief,
            DateTime aanmaakDatum,
            DateTime? afsluitDatum)
        {
            Id = id;
            Tankkaart = tankkaart;
            Chauffeur = chauffeur;
            Actief = actief;
            AanmaakDatum = aanmaakDatum;
            AfsluitDatum = afsluitDatum;
        }
    }
}
