using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ChauffeurDto
    {
        public string Id { get; set; }

        public IdentiteitPersoonDto Identiteit { get; set; }

        public ContactgegevensDto Contactgegevens { get; set; }

        public ERijbewijsType RijbewijsType { get; set; }

        public bool Indienst { get; set; }

        public List<TankkaartChauffeurDto> Tankkaarten { get; set; }

        public List<ChauffeurVoertuigDto> Voertuigen { get; set; }

        public List<AanvraagDto> Aanvragen { get; set; }
    }
}
