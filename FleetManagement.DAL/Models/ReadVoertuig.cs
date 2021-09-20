using System.Collections.Generic;

namespace FleetManagement.DAL.Models
{
    public class ReadVoertuig
    {
        public string Id { get; set; }

        public IdentiteitVoertuig Identiteit { get; set; }

        public string Kilometerstanden { get; set; }

        public List<ReadOnderhoudsbeurt> Onderhoudsbeurten { get; set; }

        public List<ReadHerstelling> Herstellingen { get; set; }

        public List<ChauffeurVoertuig> Chauffeurs { get; set; }

        public List<ReadAanvraag> Aanvragen { get; set; }
    }
}
