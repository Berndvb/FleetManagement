using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class OnderhoudsbeurtDto : AdministratieDto
    {
        public OnderhoudsbeurtDto(
        string id,
        VoertuigDto voertuig,
        DateTime uitvoeringsDatum,
        DateTime facturatieDatum,
        float prijs,
        GarageDto garage,
        List<FileDto> documenten)
        {
            Id = id;
            Voertuig = voertuig;
            UitvoeringsDatum = uitvoeringsDatum;
            FacturatieDatum = facturatieDatum;
            Prijs = prijs;
            Garage = garage;
            Documenten = documenten;
        }
    }
}
