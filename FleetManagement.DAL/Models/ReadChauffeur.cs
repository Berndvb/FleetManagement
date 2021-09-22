using FleetManagement.Framework.Models.Enums;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class ReadChauffeur
    {
        public string Id { get; set; }

        public IdentiteitPersoon Identiteit { get; set; }

        public Contactgegevens Contactgegevens { get; set; }

        public ERijbewijsType RijbewijsType { get; set; }

        public bool InDienst { get; set; }

        public List<TankkaartChauffeur> Tankkaarten { get; set; }

        public List<ChauffeurVoertuig> Voertuigen { get; set; }

        public List<ReadAanvraag> Aanvragen { get; set; }
    }
}
