using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BugFixer.Web.Areas.UserPanel.Controllers
{
    public class HomeController : BaseController
    {
        #region Fields
        private readonly IAccountService _accountService;
        #endregion


        #region Constructor
        public HomeController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        #endregion


        #region Actions 

        #region Index
        [Route("/user-panel")]
        public IActionResult Index()
        {
            return View();
        }
        #endregion

        #region Edit

        [Route("/user-panel/edit")]
        public async Task<IActionResult> Edit()
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var user = await _accountService.GetUserForEditByIdServiceAsync(userId);
            return View(user);
        }

        [HttpPost("/user-panel/edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileVM edit)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _accountService.EditProfileByIdServiceAsync(userId, edit);
            ViewBag.isSuccess = true;
            return View();
        }

        #endregion

        #endregion
    }
}
