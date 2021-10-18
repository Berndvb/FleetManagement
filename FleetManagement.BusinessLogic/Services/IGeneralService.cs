using FleetManagement.BLL.Services.Models;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using FleetManager.EFCore.Infrastructure.Pagination;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessValidationError(InputValidationCodes validationCode, string idName = null);
        PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities);
    }
}
