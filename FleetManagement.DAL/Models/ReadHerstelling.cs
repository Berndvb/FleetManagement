using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.DAL.Models
{
    public class ReadHerstelling : Facturatie
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string VerzekeringsMaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public List<File> Fotos { get; set; }

        public List<File> Documenten { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }

    }
}
