using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.DAL.Models
{
    public class TankkaartOpties
    {
        public EBrandstofType BrandstofType { get; set; }

        public string ExtraServices { get; set; }
    }
}
