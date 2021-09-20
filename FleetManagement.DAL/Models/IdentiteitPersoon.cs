using System;

namespace FleetManagement.DAL.Models
{
    public class IdentiteitPersoon
    {
        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Rijksregisternummer { get; set; }

        public DateTime Geboortedatum { get; set; }
    }
}
