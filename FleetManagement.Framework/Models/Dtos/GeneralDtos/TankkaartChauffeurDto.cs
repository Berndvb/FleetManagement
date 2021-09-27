using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class TankkaartChauffeurDto
    {
        public string Id { get; set; }

        public TankkaartDto Tankkaart { get; set; }

        public ChauffeurDto Chauffeur { get; set; }

        public bool Actief { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public DateTime AfsluitDatum { get; set; }

        public TankkaartChauffeurDto(
            string id,
            TankkaartDto tankkaart,
            ChauffeurDto chauffeur,
            bool actief,
            DateTime aanmaakDatum,
            DateTime afsluitDatum)
        {
            Id = id;
            Tankkaart = tankkaart;
            Chauffeur = chauffeur;
            AanmaakDatum = aanmaakDatum;
            AfsluitDatum = afsluitDatum;
        }
    }
}
