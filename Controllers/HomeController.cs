using AlgorithmTester.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Controllers
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
            ViewBag.UserMessage = String.Empty;
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormModel data)
        {

            // could this be a separate thread? So the site loads the view and does calculations on separate threads
            // this may require ajax...

            var tester = new CodeTester(data);
            tester.Run();

            double accuracy = tester.Accuracy;

            string userMessage = tester.UserMessage;

            Debug.WriteLine(userMessage);

            ViewBag.UserMessage = userMessage;
            ViewBag.Accuracy = accuracy + "%";


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
