using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
     
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
