using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
