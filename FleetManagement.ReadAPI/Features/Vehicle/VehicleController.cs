using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Features.Vehicle
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
