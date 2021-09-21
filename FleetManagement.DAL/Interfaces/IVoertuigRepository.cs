using FleetManagement.Domain.Models;
using FleetManagement.Framework.Models.Dtos;
using FleetManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Interfaces
{
    public interface IVoertuigRepository : IGenericRepository<ReadVoertuig>
    {
    }
}
