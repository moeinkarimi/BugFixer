using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("admin/user-list")]
        public async Task<IActionResult> Index()
        {
            IEnumerable<UserVM> userList = await _userService.GetAllServiceAsync();

            return View(userList);
        }
    }
}
