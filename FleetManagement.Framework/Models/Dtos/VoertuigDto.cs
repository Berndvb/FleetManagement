using FleetManagement.Framework.Helpers;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class VoertuigDto
    {
        public string Id { get; set; }

        public IdentiteitVoertuigDto Identiteit { get; set; }

        public List<int> Kilometerstanden { get; set; }

        public List<OnderhoudsbeurtDto> Onderhoudsbeurten { get; set; }

        public List<HerstellingDto> Herstellingen { get; set; }

        public List<ChauffeurVoertuigDto> Chauffeurs { get; set; }

        public List<AanvraagDto> Aanvragen { get; set; }

        public VoertuigDto(
            string id,
            IdentiteitVoertuigDto identiteit,
            string kilometerstanden,
            List<OnderhoudsbeurtDto> onderhoudsbeurten,
            List<HerstellingDto> herstellingen,
            List<ChauffeurVoertuigDto> chauffeurs,
            List<AanvraagDto> aanvragen)
        {
            Id = id;
            Identiteit = identiteit;
            Kilometerstanden = kilometerstanden.SplitToNumbers();
            Onderhoudsbeurten = onderhoudsbeurten;
            Herstellingen = herstellingen;
            Chauffeurs = chauffeurs;
            Aanvragen = aanvragen;
        }
    }
}
