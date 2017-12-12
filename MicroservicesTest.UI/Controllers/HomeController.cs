using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MicroservicesTest.UI.Models;
using Microsoft.Extensions.Options;
using MicroservicesTest.UI.Helpers;

namespace MicroservicesTest.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<BackEndSettings> _servicesSettings;

        public HomeController(IOptions<BackEndSettings> servicesSettings)
        {
            _servicesSettings = servicesSettings;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Settings()
        {
            var settings=new BackEndSettings(){
                CommandBaseURL = _servicesSettings.Value.CommandBaseURL,
                QueryBaseURL=_servicesSettings.Value.QueryBaseURL };
            return Json(settings);
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
