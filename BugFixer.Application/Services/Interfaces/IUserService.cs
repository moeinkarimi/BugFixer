using BugFixer.Application.ViewModels.User;
using BugFixer.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Interfaces
{
    public interface IUserService
    {
        #region Admin
        Task<IEnumerable<UserVM>> GetAllServiceAsync();
        Task<UserVM> GetServiceAsync(int userId);
        Task CreateServiceAsync(CreateUserVM user);
        Task UpdateServiceAsync(UpdateUserVM user);
        Task<UpdateUserVM> GetUserInforForUpdate(int userId);
        Task DeleteServiceAsync(int userId);


        #endregion


        Task<FilterUsersViewModel> FilterUser(FilterUsersViewModel filter);





    }
}
