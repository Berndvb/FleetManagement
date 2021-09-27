using System;

namespace FleetManagement.Framework.Models.Dtos
{
    public class IdentiteitPersoonDto
    {
        public string Id { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Rijksregisternummer { get; set; }

        public DateTime Geboortedatum { get; set; }

        public IdentiteitPersoonDto(
            string id,
            string naam,
            string voornaam,
            string rijksregisternummer,
            DateTime geboortedatum)
        {
            Id = id;
            Naam = naam;
            Voornaam = voornaam;
            Rijksregisternummer = rijksregisternummer;
            Geboortedatum = geboortedatum;
        }
    }
}
