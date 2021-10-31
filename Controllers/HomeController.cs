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
            //ViewBag.Results = new List<string>() { "", "", "" };
            //ViewBag.UserMessage = String.Empty;

            return View(new FormModel());
        }

        [HttpPost]
        public IActionResult Index(FormModel data)
        {
            // delete the empty input values which may exist from the IO table
            data.DeleteEmptyData();

            // create a new testing object
            var tester = new CodeTester(data);

            FormModel updatedModel = data.CopyInputs();

            try
            {          
                tester.Run();
                updatedModel.AddResults(tester);
            }
            catch (Exception e)
            {
                updatedModel.UserMessage = e.Message;
            }

            // pad the input/output data with empty strings incase it is insufficient for min table size
            updatedModel.PadData();

            return View(updatedModel);
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
