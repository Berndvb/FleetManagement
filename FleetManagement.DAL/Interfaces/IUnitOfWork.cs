using System;

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
        IChauffeurVoertuigRepository ChauffeurVoertuigen { get; }
        int Complete();
    }
}
