using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class ReadHerstelling : Administratie
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string VerzekeringsMaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }

    }
}
