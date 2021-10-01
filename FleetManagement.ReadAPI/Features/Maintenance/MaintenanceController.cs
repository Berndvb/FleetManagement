using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Features.Maintenance
{
    public class MaintenanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
