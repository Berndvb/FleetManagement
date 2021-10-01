using Microsoft.AspNetCore.Mvc;

namespace FleetManagement.ReadAPI.Features.Appeal
{
    public class AppealController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
