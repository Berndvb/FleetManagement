using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class HerstellingDto : FacturatieDto
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string VerzekeringsMaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public List<FileDto> Fotos { get; set; }

        public List<FileDto> Documenten { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }
    }
}
