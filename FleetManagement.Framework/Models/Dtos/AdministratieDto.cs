using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class AdministratieDto
    {
        public string Id { get; set; }

        public VoertuigDto Voertuig { get; set; }

        public DateTime UitvoeringsDatum { get; set; }

        public DateTime FacturatieDatum { get; set; }

        public float Prijs { get; set; }

        public GarageDto Garage { get; set; }

        public List<FileDto> Documenten { get; set; }
    }
}
