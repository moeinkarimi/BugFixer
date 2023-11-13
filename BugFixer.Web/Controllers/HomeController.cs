using BugFixer.Application.Services.Interfaces;
using BugFixer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BugFixer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IQuestionService _questionService;

        public HomeController(ILogger<HomeController> logger,IQuestionService questionService)
        {
            _logger = logger;
            _questionService = questionService;
        }

        public IActionResult Index()
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