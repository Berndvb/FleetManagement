using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;
using FleetManagement.Framework.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class ChauffeurRepository : GenericRepository<ReadChauffeur>, IChauffeurRepository
    {
        public ChauffeurRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
