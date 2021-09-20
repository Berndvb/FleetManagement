using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class GarageDto
    {
        public string Id { get; set; }

        public string Naam { get; set; }

        public ContactgegevensDto Contactgegevens { get; set; }

        public string Ondernemingsnummer { get; set; }

        public string Bankrekeningnummer { get; set; }
    }
}
