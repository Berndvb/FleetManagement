using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;
using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class AanvraagRepository : GenericRepository<ReadAanvraag>, IAanvraagRepository
    {
        public AanvraagRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
