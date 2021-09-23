using FleetManagement.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class ChauffeurService
    {
        public IUnitOfWork _unitOfWork { get; set; }
        public ChauffeurService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void test()
        {
            var test2 = _unitOfWork.Chauffeurs.Include(x => x.Identiteit).Select(x => x.Identiteit.Naam);
            var test = _unitOfWork.Chauffeurs.Select(x => x.Id);
        }
    }
}
