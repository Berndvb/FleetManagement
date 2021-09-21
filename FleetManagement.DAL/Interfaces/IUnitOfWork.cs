using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAanvraagRepository Aanvragen  { get; }
        IChauffeurRepository Chauffeurs { get; }
        IHerstellingRepository Herstellingen { get; }
        IOnderhoudsbeurtRepository Onderhoudsbeurten { get; }
        ITankkaartRepository Tankkaarten { get; }
        IVoertuigRepository Voertuigen { get; }
        int Complete();
    }
}
