using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FleetManagement.ReadAPI.Features.DriverManagement
{
    public class DriverManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
