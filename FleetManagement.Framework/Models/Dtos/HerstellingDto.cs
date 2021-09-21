﻿using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class HerstellingDto : AdministratieDto
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string VerzekeringsMaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }
    }
}
