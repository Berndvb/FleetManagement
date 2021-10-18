using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using System.Text;

namespace FleetManagement.BLL.Services
{
    public class GeneralService : IGeneralService
    {
        public ExecutionError ProcessValidationError(InputValidationCodes validationCode, string name = null)
        {
            var error = new ExecutionError();
            switch (validationCode)
            {
                case InputValidationCodes.IdNotFound:
                    error.Message = $"Id '{name}' could not be found.";
                    error.Code = Constants.ErrorCodes.IdNotFound;
                    break;
                case InputValidationCodes.IdNotUnique:
                    error.Message = $"Id {name} is not unique.";
                    error.Code = Constants.ErrorCodes.IdNotUnique;
                    break;
                case InputValidationCodes.MoreThanOneActiveRelation:
                    error.Message = $"Other active relations have been found for the elements that are being coupled.";
                    error.Code = Constants.ErrorCodes.MoreThanOneActiveRelation;
                    break;
            }

            return error;
        }
    }
}
