using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Domain.Models
{
    public class IdentiteitPersoon
    {
        public string Id { get; set; }

        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Rijksregisternummer { get; set; }

        public DateTime Geboortedatum { get; set; }
    }
}
