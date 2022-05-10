using ArionBank.Application.Common.Interfaces;
using ArionBank.Application.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFeedbackService _feedbackService;

        public HomeController(ILogger<HomeController> logger, IFeedbackService feedbackService)
        {
            _logger = logger;
            _feedbackService = feedbackService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(FeedbackModel model)
        {
            _feedbackService.CreateFeedback(model);

            return View();
        }

        public IActionResult Credit()
        {
            return View();
        }

        public IActionResult Card()
        {
            return View();
        }

        public IActionResult Invest()
        {
            return View();
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Contact()
        {
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