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

        [HttpGet]
        public IActionResult Index()
        {
            return View(new FormModel());
        }

        [HttpPost]
        public IActionResult Index(FormModel data)
        {
            
            // delete the empty input values which may exist from the IO table
            data.DeleteEmptyData();

            // create a new testing object
            var tester = new CodeTester(data);

            try
            { 
                // run code tester to update form model
                tester.Run();
                data.UserMessage = "Code was compiled and executed successfully.";
            }
            catch (Exception e)
            {
                data.UserMessage = e.Message;
            }

            // pad the input/output data with empty strings incase it is insufficient for min table size
            data.PadData();

            return View(data);
        }

        public IActionResult Instructions()
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
