using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class TankkaartOptiesDto
    {
        public EBrandstofType BrandstofType { get; set; }

        public List<string> ExtraServices { get; set; }
    }
}
