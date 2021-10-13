using FleetManagement.Domain.Infrastructure.Pagination;
using System.Collections.Generic;

namespace FleetManagement.BLL.Mapper.MapperSercice
{
    public class MapperService : IMapperService
    {
        public PaginatedList<TDto> GetPaginatedData<TDto, TEntity>(List<TDto> dtos, List<TEntity> entities)
        {
            var pageNumber = (entities as PaginatedList<TEntity>).PageNumber;
            var pageSize = (entities as PaginatedList<TEntity>).PageSize;
            var totalCount = (entities as PaginatedList<TEntity>).TotalCount;

            return new PaginatedList<TDto>(dtos, totalCount, pageNumber, pageSize);
        }
    }
}
