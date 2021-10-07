using FleetManagement.BLL.Services.Models;
using MediatR.Cqrs.Execution;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessIdError(IdValidationCodes validationCode, string idName);
        ExecutionError ProcessValidationError(FluentValidation.Results.ValidationResult validationResult);
    }
}
