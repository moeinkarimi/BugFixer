using BugFixer.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Domain.Interfaces
{
    public interface IRoleRepository
    {

        Task SaveChangeAsync();
        Task<IEnumerable<Role>> GetAllAsync();
        IQueryable<Role> GetQueryableRole();
        Task<Role> GetAsync(int id);
        Task AddAsync(Role role);
        void Update(Role role);
        void Delete(Role role);



        #region Permissions
        Task<IEnumerable<Permission>> PermissionListAsync();
        Task AddRolePermissionAsync(RolePermission rolePermission);
        Task<IEnumerable<RolePermission>> rolePermissionsAsync(int roleId);
        void DeleteRolePermissionAsync(RolePermission rolePermission);
        #endregion

    }
}
