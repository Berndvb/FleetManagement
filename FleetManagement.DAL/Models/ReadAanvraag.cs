using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class ReadAanvraag
    {
        public string Id { get; set; }

        public DateTime AanmaakDatum { get; set; }

        public EAanvraagType AanvraagType { get; set; }

        public DateTime? EersteDatumInplanning { get; set; }

        public DateTime? TweedeDatumInplanning { get; set; }

        public EAanvraagStatus Status { get; set; }

        public ReadVoertuig Voertuig { get; set; }

        public ReadChauffeur Chauffeur { get; set; }

        public string Message { get; set; }
    }
}
