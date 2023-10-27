using BugFixer.Application.Services.Interfaces;
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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateServiceAsync(CreateUserVM createUserVM)
        {
            User newUser = new User()
            {
                Email = createUserVM.Email,
                EmailConfirm=true,
                Mobile = createUserVM.Mobile,
                Password = createUserVM.Password,
                UserName = createUserVM.UserName,
            };

            await _userRepository.CreateAsync(newUser);
            await _userRepository.SaveChangeAsync();

           
        }

        public async Task DeleteServiceAsync(int userId)
        {
            User getUser = await _userRepository.GetAsync(userId);

            if (getUser != null)
            {
                 _userRepository.Delete(getUser);
                await _userRepository.SaveChangeAsync();
            }
        }

        public async Task<IEnumerable<UserVM>> GetAllServiceAsync()
        {
            IEnumerable<User> userList=await _userRepository.GetAllAsync();
            return userList.Select(user => new UserVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirm = user.EmailConfirm,
                Mobile = user.Mobile,
                Avatar=user.Avatar,
                CreateDate = user.CreateDate,
            }).ToList();
        }

        public async Task<UserVM> GetServiceAsync(int userId)
        {
            User getUser = await _userRepository.GetAsync(userId);

            return new UserVM()
            {
                Id = getUser.Id,
                UserName = getUser.UserName,
                Email = getUser.Email,
                EmailConfirm = getUser.EmailConfirm,
                Mobile = getUser.Mobile,
                Avatar = getUser.Avatar,
                CreateDate = getUser.CreateDate,
            };

        }

        public async Task UpdateServiceAsync(UpdateUserVM updateUserVM)
        {
            User getUser = await _userRepository.GetAsync(updateUserVM.Id);

            getUser.UserName = updateUserVM.UserName;
            getUser.Email = updateUserVM.Email;
            getUser.Mobile = updateUserVM.Mobile;

            _userRepository.Update(getUser);
            await _userRepository.SaveChangeAsync();

        }




        
    }
}
