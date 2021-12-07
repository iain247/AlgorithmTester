using AlgorithmTester.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlgorithmTester.Controllers
{
    public class InstructionsController : Controller
    {
        private readonly ILogger<InstructionsController> _logger;

        public InstructionsController(ILogger<InstructionsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Instructions()
        {
            return View();
        }
    }
}
