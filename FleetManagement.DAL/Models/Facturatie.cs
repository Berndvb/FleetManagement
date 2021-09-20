using System;

namespace FleetManagement.DAL.Models
{
    public class Facturatie
    {
        public ReadVoertuig Voertuig { get; set; }
        public DateTime UitvoeringsDatum { get; set; }

        public DateTime FacturatieDatum { get; set; }

        public float Prijs { get; set; }

        public Garage Garage { get; set; }

        public File Factuur { get; set; }
    }
}
