using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Models
{
    public class Contactgegevens
    {
        public string EmailAdres { get; set; }

        public string GsmNummer { get; set; }

        public string Telefoonnummer { get; set; }

        public Adres Adres { get; set; }
    }
}
