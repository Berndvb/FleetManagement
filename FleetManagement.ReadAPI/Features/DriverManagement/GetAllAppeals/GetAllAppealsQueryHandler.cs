using FleetManagement.BLL.Services;
using FleetManagement.BLL.Services.Model;
using FleetManagement.Framework.Constants;
using FluentValidation;
using MediatR.Cqrs.Execution;
using MediatR.Cqrs.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement.GetTotalAppeals
{
    public class GetAllAppealsQueryHandler : QueryHandler<GetAllAppealsQuery, GetAllAppealsQueryResult>
    {
        private readonly IDriverService _driverService;
        private readonly IValidator<GetAllAppealsQuery> _validator;

        public GetAllAppealsQueryHandler(
            IDriverService driverService,
            IValidator<GetAllAppealsQuery> validator)
        {
            _driverService = driverService;
            _validator = validator;
        }

        public async override Task<GetAllAppealsQueryResult> Handle(
            GetAllAppealsQuery request,
            CancellationToken cancellationToken)
        {
            //gefoefel..

            var checkedForError = await CheckForError(request);
            if (checkedForError != null)
            {
                ProcessError(checkedForError, nameof(request.));
            }
            var driverOverviews = await _driverService.GetAppealsForDriver(int.Parse(request.DriverId));

            return new GetAllAppealsQueryResult(driverOverviews);
        }

        public async Task<string> CheckForError(GetAllAppealsQuery request, params )
        {
            var requestValidated = _validator.Validate(request).IsValid;
            if (!requestValidated)
                return Constants.ErrorCodes.InvalidRequestInput;

            var idValidationCode = await _driverService.ValidateId(int.Parse(request.DriverId));
            if (idValidationCode == IdValidationCodes.IdNotUnique)
                return Constants.ErrorCodes.IdNotUnique;
            else if(idValidationCode == IdValidationCodes.IdNotFound)
                return Constants.ErrorCodes.IdNotFound;

            return null;
        }

        public void ProcessError(string errorCode, string idName)
        {
            var error = new ExecutionError { Code = errorCode };
            switch (errorCode)
            {
                case Constants.ErrorCodes.InvalidRequestInput:
                    error.Message = "Request-parameters are invalid.";
                    break;
                case Constants.ErrorCodes.IdNotFound:
                    error.Message = $"Id {idName} wasn't found.";
                    break;
                case Constants.ErrorCodes.IdNotUnique:
                    error.Message = $"Id {idName} isn't unique.";
                    break;
                default:
                    break;
            }
            BadRequest(error);
        }
    }
}
