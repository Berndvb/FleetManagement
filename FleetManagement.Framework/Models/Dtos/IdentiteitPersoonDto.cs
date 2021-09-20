using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class IdentiteitPersoonDto
    {
        public string Naam { get; set; }

        public string Voornaam { get; set; }

        public string Rijksregisternummer { get; set; }

        public DateTime Geboortedatum { get; set; }
    }
}
