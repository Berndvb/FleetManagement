using FleetManagement.BLL.Services.Models;
using FleetManagement.Domain.Infrastructure.Pagination;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessValidationError(InputValidationCodes validationCode, string idName = null);
        PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities);
    }
}
