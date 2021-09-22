using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;

namespace FleetManagement.Framework.Models.Dtos
{
    public class HerstellingDto : AdministratieDto
    {
        public DateTime DatumVoorval { get; set; }

        public string SchadeOmschrijving { get; set; }

        public string Verzekeringsmaatschappij { get; set; }

        public string ReferentieNummer { get; set; }

        public EHerstellingStatus HerstellingStatus { get; set; }


        public HerstellingDto(
            DateTime datumVoorval,
            string schadeOmschrijving,
            string verzekeringmaatschappij,
            string referentieNummer,
            EHerstellingStatus herstellingStatus)
        {
            DatumVoorval = datumVoorval;
            SchadeOmschrijving = schadeOmschrijving;
            Verzekeringsmaatschappij = verzekeringmaatschappij;
            ReferentieNummer = referentieNummer;
            HerstellingStatus = herstellingStatus;
        }

        public HerstellingDto(
            DateTime datumVoorval,
            string schadeOmschrijving,
            string verzekeringmaatschappij,
            string referentieNummer,
            EHerstellingStatus herstellingStatus,
            string id,
            VoertuigDto voertuig,
            DateTime uitvoeringsDatum,
            DateTime facturatieDatum,
            float prijs,
            GarageDto garage,
            List<FileDto> documenten)
        {
            DatumVoorval = datumVoorval;
            SchadeOmschrijving = schadeOmschrijving;
            Verzekeringsmaatschappij = verzekeringmaatschappij;
            ReferentieNummer = referentieNummer;
            HerstellingStatus = herstellingStatus;
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
