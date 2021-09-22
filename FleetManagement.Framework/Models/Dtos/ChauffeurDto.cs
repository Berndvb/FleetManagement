using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ChauffeurDto
    {
        public string Id { get; set; }

        public IdentiteitPersoonDto Identiteit { get; set; }

        public ContactgegevensDto Contactgegevens { get; set; }

        public ERijbewijsType RijbewijsType { get; set; }

        public bool InDienst { get; set; }

        public List<TankkaartChauffeurDto> Tankkaarten { get; set; }

        public List<ChauffeurVoertuigDto> Voertuigen { get; set; }

        public List<AanvraagDto> Aanvragen { get; set; }

        public ChauffeurDto(
            string id,
            IdentiteitPersoonDto identiteit,
            ContactgegevensDto contactgegevens,
            ERijbewijsType rijbewijsType,
            bool inDienst,
            List<TankkaartChauffeurDto> tankkaarten,
            List<ChauffeurVoertuigDto> voertuigen,
            List<AanvraagDto> aanvragen)
        {
            Id = id;
            Identiteit = identiteit;
            Contactgegevens = contactgegevens;
            RijbewijsType = rijbewijsType;
            InDienst = inDienst;
            Tankkaarten = tankkaarten;
            Voertuigen = voertuigen;
            Aanvragen = aanvragen;
        }
    }
}
