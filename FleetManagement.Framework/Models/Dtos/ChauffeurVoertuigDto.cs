using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
