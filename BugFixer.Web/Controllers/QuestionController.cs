using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Controllers
{
    public class QuestionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
