using BugFixer.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("submit-question")]
        public async Task<IActionResult> Create()
        {
            return View();
        }
    }
}
