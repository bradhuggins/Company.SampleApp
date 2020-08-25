#region Using Statements
using System.Diagnostics;
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

    }
}
