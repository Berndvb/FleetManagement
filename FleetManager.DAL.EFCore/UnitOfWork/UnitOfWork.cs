using FleetManagement.Domain.Interfaces;
using FleetManagement.EFCore.Infrastructure;
using FleetManager.EFCore.Repositories;

namespace FleetManager.EFCore.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _context;

        public IAanvraagRepository Aanvragen { get; private set; }

        public IChauffeurRepository Chauffeurs { get; private set; }

        public IHerstellingRepository Herstellingen { get; private set; }

        public IOnderhoudsbeurtRepository Onderhoudsbeurten { get; private set; }

        public ITankkaartRepository Tankkaarten { get; private set; }

        public IVoertuigRepository Voertuigen { get; private set; }

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
            Aanvragen = new AanvraagRepository(_context);
            Chauffeurs = new ChauffeurRepository(_context);
            Herstellingen = new HerstellingRepository(_context);
            Onderhoudsbeurten = new OnderhoudsbeurtRepository(_context);
            Tankkaarten = new TankkaartRepository(_context);
            Voertuigen = new VoertuigRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose() // when to dispose?
        {
            _context.Dispose();
        }
    }
}
