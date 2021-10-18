using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace FleetManagement.Domain.Models
{
    public abstract class Administration : IBaseClass
    {
        public int Id { get; private set; }

        public Vehicle Vehicle { get; private set; }

        public DateTime CreationDate { get; private set; }

        public DateTime? InvoiceDate { get; private set; }

        public float Price { get; private set; }

        public Garage Garage { get; private set; }

        public List<File> Documents { get; private set; }

        public Driver Driver { get; private set; }

        public Appeal Appeal { get; private set; }
    }
}
