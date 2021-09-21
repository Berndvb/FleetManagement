using System;
using System.ComponentModel.DataAnnotations;

namespace FleetManager.EFCore.Models
{
    public class IdentiteitPersoon
    {
        public string Naam { get; set; }

        public string Voornaam { get; set; }

        [Key]
        public string Rijksregisternummer { get; set; }

        public DateTime Geboortedatum { get; set; }
    }
}
