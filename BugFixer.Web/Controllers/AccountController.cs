using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Account;
using BugFixer.Application.ViewModels.User;
using EShop.Application.Convertors;
using EShop.Application.Senders;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private IViewRenderService _viewRender;

        public AccountController(IAccountService accountService, IViewRenderService viewRender)
        {
            _accountService = accountService;
            _viewRender = viewRender;
        }

        [Route("/register")]
        public  IActionResult Register()
        {
            return View();
        }

        [HttpPost("/register")]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid)
            {

                return View(register);

            }

            if (await _accountService.IsEmailExistServiceAsync(register.Email) == true)
            {
                ModelState.AddModelError("Email", "حساب کاربری با این ایمیل موجود می باشد");
                return View(register);
            };  

            if (await _accountService.IsUserNameExistServiceAsync(register.UserName) == true)
            {
                ModelState.AddModelError("UserName", "حساب کاربری از قبل موجود می باشد");
                return View(register);
            };

            UserVM user = await _accountService.RegisterServiceAsync(register);

            string body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی", body);

            return View("SuccessRegister", user);
        }
    }
}
