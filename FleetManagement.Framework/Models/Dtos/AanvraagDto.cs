using FleetManagement.Framework.Models.Enums;
using System;

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

        public AanvraagDto(
            string id, 
            DateTime aanmaakDatum, 
            EAanvraagType aanvraagType, 
            DateTime? eersteDatumInplanning, 
            DateTime? tweedeDatumInplanning, 
            EAanvraagStatus status, 
            VoertuigDto voertuig,
            ChauffeurDto chauffeur, 
            string message)
        {
            Id = id;
            AanmaakDatum = aanmaakDatum;
            AanvraagType = aanvraagType;
            EersteDatumInplanning = eersteDatumInplanning;
            TweedeDatumInplanning = tweedeDatumInplanning;
            Status = status;
            Voertuig = voertuig;
            Chauffeur = chauffeur;
            Message = message;
        }
    }
}
