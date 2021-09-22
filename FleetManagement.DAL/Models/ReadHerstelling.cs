using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Domain.Models
{
    public class ReadHerstelling : Administratie
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string Verzekeringsmaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }

    }
}
