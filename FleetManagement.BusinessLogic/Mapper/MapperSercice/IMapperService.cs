using FleetManagement.Domain.Infrastructure.Pagination;
using System.Collections.Generic;

namespace FleetManagement.BLL.Mapper.MapperSercice
{
    public interface IMapperService
    {
        PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities);
    }
}
