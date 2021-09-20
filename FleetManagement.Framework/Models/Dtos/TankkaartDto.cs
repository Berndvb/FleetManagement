using FleetManagement.Framework.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Framework.Models.Dtos
{
    public class TankkaartDto
    {
        public string Kaartnummer { get; set; }

        public DateTime GeldigheidsDatum { get; set; }

        public string Pincode { get; set; }

        public EAuthenticatieType AuthenticatieType { get; set; }

        public TankkaartOptiesDto TankkaartOpties { get; set; }

        public bool Geblokkeerd { get; set; }

        public List<TankkaartChauffeurDto> Chauffeurs { get; set; }
    }
}
