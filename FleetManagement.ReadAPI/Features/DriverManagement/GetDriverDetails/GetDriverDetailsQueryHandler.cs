using FleetManagement.BLL.Services;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetDriverDetails
{
    public class GetDriverDetailsQueryHandler : QueryHandler<GetDriverDetailsQuery, GetDriverDetailsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IGeneralService _generalService;
        private readonly IValidator<GetDriverDetailsQuery> _validator;

        public GetDriverDetailsQueryHandler(
            IDriverService driverService,
            IGeneralService generalService,
            IValidator<GetDriverDetailsQuery> validator)
        {
            _driverService = driverService;
            _generalService = generalService;
            _validator = validator;
        }

        public async override Task<GetDriverDetailsQueryResult> Handle(
            GetDriverDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
            {
                var validationError = _generalService.ProcessValidationError(validationResult);
                return BadRequest(validationError);
            }

            var idError = await _driverService.CheckforIdError(request.DriverId);
            if (idError != null)
                return BadRequest(idError);

            var driverDetails = await _driverService.GetDriverDetails(request.DriverId);

            return new GetDriverDetailsQueryResult(driverDetails);
        }
    }
}
