using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Interfaces.Repositories;
using MediatR.Cqrs.Execution;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.BLL.Services
{
    public class DriverService : IDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGeneralService _generalService;

        public DriverService(
            IUnitOfWork unitOfWork,
            IGeneralService generalService)
        {
            _unitOfWork = unitOfWork;
            _generalService = generalService;
        }

        public async Task<ExecutionError> ValidateId(CancellationToken cancellationToken, int id)
        {
            var ids = await _unitOfWork.Drivers.GetIds(id, cancellationToken);

            var validationCode =  ids.Count switch
            {
                0 => InputValidationCodes.IdNotFound,
                > 1 => InputValidationCodes.IdNotUnique,
                _ => InputValidationCodes.OK,
            };

            if (validationCode != InputValidationCodes.OK)
                return _generalService.ProcessValidationError(validationCode, nameof(id));

            return null;
        }
    }
}
