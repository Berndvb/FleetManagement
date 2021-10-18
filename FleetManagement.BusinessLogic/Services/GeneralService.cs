using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Constants;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using FleetManager.EFCore.Infrastructure.Pagination;

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
    }
}
