using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
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
            if(!ModelState.IsValid)
                return View(edit);
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            await _accountService.EditProfileByIdServiceAsync(userId, edit);
            ViewBag.isSuccess = true;
            return View();
        }

        #endregion

        #region ChangePassword
        [Route("/user-panel/change-password")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost("/user-panel/change-password")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM change)
        {
            int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (!ModelState.IsValid)
                return View(change);

            if (!await _accountService.ChangePasswordServiceAsync(userId, change))
                ModelState.AddModelError("OldPassword", "رمز عبور وارد شدده صحیح نمی باشد.");

            await _accountService.ChangePasswordServiceAsync(userId, change);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            TempData["ChangePasswordSuccess"] = true;

            return Redirect("/login");
        }
        #endregion

        #endregion
    }
}
