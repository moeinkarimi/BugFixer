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
                Avatar = "Default.jpg",
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

        public async Task<bool> IsEmailExistServiceAsync(string email)
        {
            return await _userRepository.IsEmailExistAsync(email);
        }

        public async Task<bool> IsUserNameExistServiceAsync(string userName)
        {
            return await _userRepository.IsUserNameExistAsync(userName);
        }
    }
}
