﻿using FleetManagement.BLL.Features.Read.VehicleManagement.GetAllVehicles;
using MediatR;
using MediatR.Cqrs;
using MediatR.Cqrs.Execution;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        private readonly IMediator _mediator;

        public VehicleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllVehicles(
          [FromModel] GetVehiclesQuery getAllVehiclesQuery,
          CancellationToken cancellationToken)
        {
            var getAllVehiclesQueryResult = await _mediator.Send(getAllVehiclesQuery, cancellationToken);

            return getAllVehiclesQueryResult.ToActionResult();
        }
    }
}
