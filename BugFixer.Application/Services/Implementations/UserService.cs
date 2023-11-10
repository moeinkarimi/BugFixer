using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.User;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.User;
using EShop.Application.Generator;
using EShop.Application.Security;
using Microsoft.EntityFrameworkCore;

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
                EmailConfirm = true,
                Mobile = createUserVM.Mobile,
                Password = PasswordHelper.EncodePasswordMd5(createUserVM.Password),
                UserName = createUserVM.UserName,
                ActiveCode = NameGenerator.GenerateUniqCode(),
                Avatar = "Default.png",
                RoleId = createUserVM.RoleId,
                

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

        public async Task<FilterUsersViewModel> FilterUser(FilterUsersViewModel filter)
        {
            IQueryable<User> query = _userRepository.UserListForFilter();

            if (!string.IsNullOrEmpty(filter.UserName))
            {
                query = query.Where(u => EF.Functions.Like(u.UserName, $"%{filter.UserName.Trim().ToLower()}%"));
            }

            await filter.Paging(query);

            return filter;
        }

        public async Task<IEnumerable<UserVM>> GetAllServiceAsync()
        {
            IEnumerable<User> userList = await _userRepository.GetAllAsync();
            return userList.Select(user => new UserVM()
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                EmailConfirm = user.EmailConfirm,
                Mobile = user.Mobile,
                Avatar = user.Avatar,
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

        public async Task<UpdateUserVM> GetUserInforForUpdate(int userId)
        {
            User getUser = await _userRepository.GetAsync(userId);

            return new UpdateUserVM()
            {
                Id = getUser.Id,
                UserName = getUser.UserName,
                Email = getUser.Email,
                Mobile = getUser.Mobile,
                Password = getUser.Password,
                RoleId = getUser.RoleId,
            };
        }

        public async Task UpdateServiceAsync(UpdateUserVM updateUserVM)
        {
            User getUser = await _userRepository.GetAsync(updateUserVM.Id);

            getUser.UserName = updateUserVM.UserName;
            getUser.Email = updateUserVM.Email;
            getUser.Mobile = updateUserVM.Mobile;
            getUser.Password=updateUserVM.Password;
            getUser.RoleId=updateUserVM.RoleId;

            _userRepository.Update(getUser);
            await _userRepository.SaveChangeAsync();

        }





    }
}
