using FleetManagement.BLL.Services.Models;
using FleetManagement.Framework.Paging;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessValidationError(InputValidationCodes validationCode, string idName = null);
        PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities);
        IActionResult ValidateEntity<TRes>(TRes entity) where TRes : class;
        BadRequestObjectResult ValidateId(int id);
    }
}
