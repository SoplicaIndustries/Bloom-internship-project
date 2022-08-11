using WebPanel.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace WebPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Transactions()
        {
            return View();
        }

        public IActionResult Invoices()
        {

            return View();
        }

        public IActionResult Products()
        {
            return View();

        }

        public IActionResult Customers()
        {
         

            return View();
        }

       
        public decimal SendBalance(decimal es)
        {

            
            return es;
        }
    }
}