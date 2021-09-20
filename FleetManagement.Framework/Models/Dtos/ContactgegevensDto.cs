using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class ContactgegevensDto
    {
        public string EmailAdres { get; set; }

        public string GsmNummer { get; set; }

        public string Telefoonnummer { get; set; }

        public AdresDto Adres { get; set; }
    }
}
