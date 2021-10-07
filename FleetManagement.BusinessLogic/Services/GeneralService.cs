using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using System.Text;

namespace FleetManagement.BLL.Services
{
    public class GeneralService : IGeneralService
    {
        public ExecutionError ProcessIdError(IdValidationCodes validationCode, string idName)
        {
            var error = new ExecutionError();
            switch (validationCode)
            {
                case IdValidationCodes.IdNotFound:
                    error.Message = $"Id '{idName}' could not be found.";
                    error.Code = Constants.ErrorCodes.IdNotFound;
                    break;
                case IdValidationCodes.IdNotUnique:
                    error.Message = $"Id {idName} is not unique.";
                    error.Code = Constants.ErrorCodes.IdNotUnique;
                    break;
            }

            return error;
        }

        public ExecutionError ProcessValidationError(FluentValidation.Results.ValidationResult validationResult)
        {
            StringBuilder errorMessages = new StringBuilder();
            validationResult.Errors.ForEach(error => errorMessages.Append(error));

            var error = new ExecutionError(errorMessages.ToString(), Constants.ErrorCodes.InvalidRequestInput);

            return error;
        }
    }
}
