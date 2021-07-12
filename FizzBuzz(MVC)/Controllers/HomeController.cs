using FizzBuzzMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;

namespace FizzBuzzMVC.Controllers
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

        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzz model = new();

            model.FizzValue = 3;
            model.BuzzValue = 5;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult FBPage(FizzBuzz fizzBuzz)
        {
            // Variables
            bool booFizz;
            bool booBuzz;

            List<string> fbItems = new();

            // Loop through 1 - 100.
            // Identify if divisible. 
            for (int i = 1; i <= 100; i++)
            {
                booFizz = (i % fizzBuzz.FizzValue == 0);
                booBuzz = (i % fizzBuzz.BuzzValue == 0);

                // Condition
                if (booFizz == true && booBuzz == true)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (booFizz == true)
                {
                    fbItems.Add("Fizz");
                }
                else if (booBuzz == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }

            //
            fizzBuzz.Result = fbItems;

            return View(fizzBuzz);
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