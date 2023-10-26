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

        #endregion
    }
}
