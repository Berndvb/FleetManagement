using System;
using System.Collections.Generic;

namespace FleetManagement.Domain.Models
{
    public class Administration
    {
        public int Id { get; set; }

        public ReadVehicle Vehicle { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime InvoiceDate { get; set; }

        public float Price { get; set; }

        public Garage Garage { get; set; }

        public List<File> Documents { get; set; }
    }
}
