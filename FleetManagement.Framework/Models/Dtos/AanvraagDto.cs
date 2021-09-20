using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class AanvraagDto
    {
        public string Id { get; set; }
        public DateTime AanmaakDatum { get; set; }

        public EAanvraagType AanvraagType { get; set; }

        public DateTime? EersteDatumInplanning { get; set; }

        public DateTime? TweedeDatumInplanning { get; set; }

        public EAanvraagStatus Status { get; set; }

        public VoertuigDto Voertuig { get; set; }

        public ChauffeurDto Chauffeur { get; set; }

        public string Message { get; set; }
    }
}
