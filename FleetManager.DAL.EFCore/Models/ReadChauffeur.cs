using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Models
{
    public class ReadChauffeur
    {
        public string Id { get; set; }

        public IdentiteitPersoon Identiteit { get; set; }

        public Contactgegevens Contactgegevens { get; set; }

        public ERijbewijsType RijbewijsType { get; set; }

        public bool Indienst { get; set; }

        public List<TankkaartChauffeur> Tankkaarten { get; set; }

        public List<ChauffeurVoertuig> Voertuigen { get; set; }

        public List<ReadAanvraag> Aanvragen { get; set; }
    }
}
