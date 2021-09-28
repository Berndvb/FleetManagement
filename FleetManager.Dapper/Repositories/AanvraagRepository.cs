using FleetManagement.Domain.Interfaces;
using FleetManagement.Domain.Models;
using FleetManager.Dapper.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManager.Dapper.Repositories
{
    public class AanvraagRepository : GenericRepository<Appeal>
    {
        public AanvraagRepository(DapperContextFactory dapperContextFactory) : base(dapperContextFactory)
        {
        }
    }
}
