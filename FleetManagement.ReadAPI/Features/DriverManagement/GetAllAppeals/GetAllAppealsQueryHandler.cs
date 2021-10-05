using FleetManagement.BLL.Services;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAllAppealsQueryHandler : QueryHandler<GetAllAppealsQuery, GetAllAppealsQueryResult>
    {
        private readonly IDriverService _driverService;

        public GetAllAppealsQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        public async override Task<GetAllAppealsQueryResult> Handle(
            GetAllAppealsQuery request,
            CancellationToken cancellationToken)
        {
            var driverOverviews = await _driverService.GetAppealsForDriver(int.Parse(request.DriverId));

            return new GetAllAppealsQueryResult(driverOverviews);
        }
    }
}
