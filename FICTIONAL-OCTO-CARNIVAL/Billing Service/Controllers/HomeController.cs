using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Billing_Service.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<Customers> CustomersList = CustomerController_.Get();

            return View(CustomersList);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}