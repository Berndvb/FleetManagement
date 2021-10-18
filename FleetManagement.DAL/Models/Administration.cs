using FleetManagement.Domain.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public abstract class Administration : IBaseClass
    {
        public int Id { get; set; }

        public Vehicle Vehicle { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public float Price { get; set; }

        public Garage Garage { get; set; }

        public List<File> Documents { get; set; }

        public Driver Driver { get; set; }

        public Appeal Appeal { get; set; }
    }
}
