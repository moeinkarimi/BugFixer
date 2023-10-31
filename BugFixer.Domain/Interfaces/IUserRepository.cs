using BugFixer.Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task SaveChangeAsync();
        #region Admin
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetAsync(int userId);
        Task CreateAsync(User user);
        void Update(User user);
        void Delete(User user);
        IQueryable<User> UserListForFilter();

        #endregion




        #region Account
        Task<User> RegisterAsync(User user);
        Task<User> LoginUserAsync(string email, string password);
        Task<bool> IsUserNameExistAsync(string userName);
        Task<bool> IsEmailExistAsync(string email);
        Task<User> GetUserByActiveCodeAsync(string activeCode);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserForEditByIdAsync(int id);

        #endregion
    }
}
