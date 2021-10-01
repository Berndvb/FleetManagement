using Microsoft.AspNetCore.Mvc;

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
