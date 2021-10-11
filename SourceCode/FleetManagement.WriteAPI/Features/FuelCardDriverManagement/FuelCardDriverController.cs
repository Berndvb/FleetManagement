using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.WriteAPI.Features.FuelCardDriverManagement
{
    public class FuelCardDriverController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
