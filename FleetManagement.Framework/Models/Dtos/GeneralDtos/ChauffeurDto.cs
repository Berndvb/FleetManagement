using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ChauffeurDto
    {
        public string Id { get; set; }

        public IdentiteitPersoonDto Identiteit { get; set; }

        public ContactgegevensDto Contactgegevens { get; set; }

        public EDriversLicenseType RijbewijsType { get; set; }

        public bool InDienst { get; set; }

        public List<TankkaartChauffeurDto> Tankkaarten { get; set; }

        public List<ShowVoertuigInfoDto> Voertuigen { get; set; }

        public List<AanvraagDto> Aanvragen { get; set; }

        public ChauffeurDto(
            string id,
            IdentiteitPersoonDto identiteit,
            ContactgegevensDto contactgegevens,
            EDriversLicenseType rijbewijsType,
            bool inDienst,
            List<TankkaartChauffeurDto> tankkaarten,
            List<ShowVoertuigInfoDto> voertuigen,
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
