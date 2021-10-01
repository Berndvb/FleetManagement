using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Features.Repare
{
    public class RepareController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
