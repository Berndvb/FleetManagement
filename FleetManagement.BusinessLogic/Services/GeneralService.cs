using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Constants;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        public PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities)
        {
            var pageNumber = (entities as PaginatedList<TEntity>).PageNumber;
            var pageSize = (entities as PaginatedList<TEntity>).PageSize;
            var totalCount = (entities as PaginatedList<TEntity>).TotalCount;

            return new PaginatedList<TDto>(dtos, totalCount, pageNumber, pageSize);
        }
        
        #region logic for service-pattern

        //logic to implement service-pattern for GetDriverDetails (as practice)
        public async Task<IActionResult> SingleReturnToActionResult<TRes>(TRes entity) where TRes : class
        {
            if (entity == null)
            {
                var error = new ErrorResponse("We couldn't find and retrieve any data.", Constants.ErrorCodes.DataNotFound);
                return new BadRequestObjectResult(error);
            }

            return new OkObjectResult(entity);
        }

        public BadRequestObjectResult IsValidId(int id)
        {
            if (id <= 0)
            {
                var error = new ErrorResponse("Id isn't valid.", Constants.ErrorCodes.InvalidRequestInput);
                return new BadRequestObjectResult(error);
            }

            return null;
        }

        public class ErrorResponse
        {
            public string Message { get; set; }

            public string Code { get; set; }

            public ErrorResponse(string message, string code)
            {
                Message = message;
                Code = code;
            }
        }

        #endregion
    }
}
