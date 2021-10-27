using FleetManagement.BLL.Services.Models;
using MediatR.Cqrs.Execution;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FleetManagement.Domain.Models;
using FleetManager.EFCore.Infrastructure.Pagination;
using FleetManagement.Framework.Paging;
using Microsoft.AspNetCore.Mvc;
using static FleetManagement.BLL.Services.GeneralService;

namespace FleetManagement.BLL.Services
{
    public interface IGeneralService
    {
        ExecutionError ProcessValidationError(InputValidationCodes validationCode, string idName = null);
        PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities);
        IActionResult SingleReturnToActionResult<TRes>(TRes entity) where TRes : class;
        BadRequestObjectResult IsValidId(int id);
    }
}
