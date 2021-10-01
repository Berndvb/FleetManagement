using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Features.FuelCard
{
    public class FuelCardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
