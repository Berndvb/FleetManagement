using FleedManagement.Api.Features.Chauffeur.AddChauffeur;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace FleedManagement.Api.Features
{
    [ApiController]
    public class ChauffeurController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(AddChauffeurCommandResult), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult AddChauffeur(AddChauffeurCommand addChauffeurCommand) 
        {
            //Add addChauffeurCommand to mediator
            //Return mediator-result

            return Ok();
        }
    }
}
