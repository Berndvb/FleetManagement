using FleetManagement.BLL.Services;
using FleetManagement.BLL.Services.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.Driver.GetDriverDetails
{
    public class GetDriverDetailsQueryHandler
    {
        private readonly IDriverService _driverService;

        public GetDriverDetailsQueryHandler(
            IDriverService driverService)
        {
            _driverService = driverService;
        }

        //public  override Task<GetDriverDetailsQueryResult> Handle(
        //    GetDriverDetailsQuery request,
        //    CancellationToken cancellationToken)
        //{
        //    //switch (await _driverService.DriverIdIsUnique(request.DriverId))
        //    //{
        //    //    case InputValidationCodes.IdNotFound:
        //    //        return 
        //    //    default:
        //    //        break;
        //    //}

        //    throw new NotImplementedException();

        //    var driverDetails = _driverService.GetDriverDetails(request.DriverId);

        //    return new GetDriverDetailsQueryResult();
        //}
    }
}
