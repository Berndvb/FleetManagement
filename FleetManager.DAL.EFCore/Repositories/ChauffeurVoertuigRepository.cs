using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManagement.EFCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.EFCore.Repositories
{
    public class ChauffeurVoertuigRepository : GenericRepository<ChauffeurVoertuig>, IChauffeurVoertuigRepository
    {
        public ChauffeurVoertuigRepository(DatabaseContext context) : base(context)
        {
        }
    }
}
