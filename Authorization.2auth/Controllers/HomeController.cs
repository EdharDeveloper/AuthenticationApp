using Authorization._2auth.Models;
using Authorization._2auth.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Authorization._2auth.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly ICookieSeedAppService _cookieSeedAppService;

        public HomeController(ILogger<HomeController> logger, ICookieSeedAppService cookieSeedAppService)
        {
            _logger = logger;
            _cookieSeedAppService = cookieSeedAppService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            _cookieSeedAppService.Seed("hello!");
            Console.WriteLine(_cookieSeedAppService.GetType().Name);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}