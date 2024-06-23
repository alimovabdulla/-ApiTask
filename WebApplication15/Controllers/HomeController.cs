using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using WebApplication15.Models;

namespace WebApplication15.Controllers
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

            return View();
        }
        [HttpPost]
        public IActionResult Index(string cityName)
        {
            string apiKey = "4555623f4b5f235427590131a9d5dca7";

            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&mode=xml&lang=az&units=metric&appid={apiKey}";

            XDocument document = XDocument.Load(apiUrl);

            ViewBag.v1 = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            ViewBag.v2 = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;
            ViewBag.v3 = document.Descendants("sun").ElementAt(0).Attribute("rise").Value;
            ViewBag.v4 = document.Descendants("sun").ElementAt(0).Attribute("set").Value;
            ViewBag.v5 = document.Descendants("city").ElementAt(0).Attribute("name").Value;


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
