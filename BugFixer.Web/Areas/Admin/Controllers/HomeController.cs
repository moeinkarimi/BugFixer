using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserVM> userList=await _userService.GetAllServiceAsync();
            return View(userList);
        }
    }
}
