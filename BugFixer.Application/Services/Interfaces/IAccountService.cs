using BugFixer.Application.ViewModels.Account;
using BugFixer.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Interfaces
{
    public interface IAccountService
    {

        Task<UserVM> RegisterServiceAsync(RegisterVM vM);
        Task<UserVM> LoginUserServiceAsync(LoginVM login);
        Task<bool> IsUserNameExistServiceAsync(string userName);
        Task<bool> IsEmailExistServiceAsync(string email);
        Task<UserVM> ActiveAccountServiceAsync(string activeCode);
        Task<UserVM> GetUserByEmailServiceAsync(string email);
        Task<bool> ResetPasswordServiceAsync(string activeCode, ResetPasswordVM resetPassword);
        Task<EditProfileVM> GetUserForEditByIdServiceAsync(int id);
        Task EditProfileByIdServiceAsync(int id, EditProfileVM edit);

    }
}
