using FleetManagement.BLL.Services.Models;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessValidationError(InputValidationCodes validationCode, string idName = null);
    }
}
