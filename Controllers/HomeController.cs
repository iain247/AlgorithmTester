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

            // could this be a separate thread? So the site loads the view and does calculations on separate threads
            // this may require ajax...
            data.PrintValues();

            data.DeleteEmptyData();

            data.PrintValues();

            var tester = new CodeTester(data);
            FormModel updatedModel = new FormModel()
            {
                Code = data.Code,
                InputData = data.InputData,
                OutputData = data.OutputData,
            };
            /*
             * COULD UPDATED THE MODEL WITH A SINGLE METHOD CALL
             * FOR EXAMPLE: UPDATEDMODEL.UPDATE(CODETESTER);
             */
            try
            {
                
                tester.Run();
                updatedModel.Accuracy = tester.Accuracy.ToString() + "%";
                updatedModel.Results = tester.Results;
                updatedModel.UserMessage = "Code was compiled and executed successfully.";
                updatedModel.TestArguments = tester.TestArguments;
                updatedModel.Times = tester.Times;
            }
            catch (Exception e)
            {
                updatedModel.UserMessage = e.Message;
            }


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
