using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    public class Dbc : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
