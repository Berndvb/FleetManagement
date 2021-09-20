using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class FacturatieDto
    {
        public VoertuigDto Voertuig { get; set; }

        public DateTime UitvoeringsDatum { get; set; }

        public DateTime FacturatieDatum { get; set; }

        public float Prijs { get; set; }

        public GarageDto Garage { get; set; }

        public FileDto Factuur { get; set; }
    }
}
