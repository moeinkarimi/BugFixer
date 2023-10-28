using BugFixer.Application.Convertors;
using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Account;
using BugFixer.Application.ViewModels.User;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.User;
using EShop.Application.Generator;
using EShop.Application.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;
        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserVM> RegisterServiceAsync(RegisterVM vM)
        {
            var hashedPassword = PasswordHelper.EncodePasswordMd5(vM.Password);
            var user = new User
            {
                UserName = vM.UserName,
                Email = vM.Email,
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Password = hashedPassword,
                Avatar = "Default.png",
                CreateDate = DateTime.Now,
                Mobile = vM.Mobile == null ? null : vM.Mobile,
            };
            var returnedUser = await _userRepository.RegisterAsync(user);
            await _userRepository.SaveChangeAsync();
            return new UserVM
            {
                UserName = returnedUser.UserName,
                Email = returnedUser.Email,
                ActiveCode = returnedUser.ActiveCode,
            };
        }

        public async Task<UserVM> LoginUserServiceAsync(LoginVM login)
        {
            var email = FixedText.FixEmail(login.Email);
            var password = PasswordHelper.EncodePasswordMd5(login.Password);

            var user = await _userRepository.LoginUserAsync(email, password);

            if (user != null)
            {
                return new UserVM
                {
                    Id = user.Id,
                    EmailConfirm = user.EmailConfirm,
                    Email = user.Email,
                    Avatar = user.Avatar,
                    Role = user.Role,
                    UserName = user.UserName,
                };
            }
            else
            {
                return null;
            }

        }

        public async Task<bool> IsEmailExistServiceAsync(string email)
        {
            return await _userRepository.IsEmailExistAsync(email);
        }

        public async Task<bool> IsUserNameExistServiceAsync(string userName)
        {
            return await _userRepository.IsUserNameExistAsync(userName);
        }

        public async Task<UserVM> ActiveAccountServiceAsync(string activeCode)
        {
            var user = await _userRepository.GetUserByActiveCodeAsync(activeCode);
            if(user == null || user.EmailConfirm)
            {
                return null;
            }

            user.EmailConfirm = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();

            await _userRepository.SaveChangeAsync();
            return new UserVM {
                UserName= user.UserName,
            };
        }
    }
}
