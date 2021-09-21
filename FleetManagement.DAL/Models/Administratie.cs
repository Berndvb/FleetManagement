using System;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Administratie
    {
        public string Id { get; set; }

        public ReadVoertuig Voertuig { get; set; }

        public DateTime UitvoeringsDatum { get; set; }

        public DateTime FacturatieDatum { get; set; }

        public float Prijs { get; set; }

        public Garage Garage { get; set; }

        public List<File> Documenten { get; set; }
    }
}
