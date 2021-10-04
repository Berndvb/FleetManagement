using FleetManagement.BLL.Services.Model;
using FleetManagement.Domain.Interfaces;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class GeneralService<TEntity> where TEntity : class, IBaseClass
    {
        private readonly IUnitOfWork _unitOfWork;

        public GeneralService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<InputValidationCodes> ValidateId(int id)
        {
            var ids = await _unitOfWork.Drivers.GetIds(id); //find a way to avoid access via a specific repo (looks weird) + add it to DI

            return ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };
        }
    }
}
