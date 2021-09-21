using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Models
{
    public class Adres
    {
        public string Id { get; set; }

        public string Straat { get; set; }

        public string Stad { get; set; }

        public string Postcode { get; set; }
    }
}
