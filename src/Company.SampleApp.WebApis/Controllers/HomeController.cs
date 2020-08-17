#region Using Statements
using System.Diagnostics;
using Company.SampleApp.WebApis.Models;
using Microsoft.AspNetCore.Mvc; 
#endregion

namespace Company.SampleApp.WebApis.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
