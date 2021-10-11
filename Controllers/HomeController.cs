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
            return View();
        }

        [HttpPost]
        public IActionResult Index(FormModel data)
        {
            Console.Write("test");
            Console.Write(data.Code);
            Console.Write(data.InputData.Count);
            Console.Write(data.OutputData.Count);
            Console.Write(data.Accuracy);
            Console.Write(data.Speed);
            System.Diagnostics.Debug.WriteLine("test");
            System.Diagnostics.Debug.WriteLine(data.Code);
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
