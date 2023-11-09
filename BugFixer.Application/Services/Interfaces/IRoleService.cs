using BugFixer.Application.ViewModels.Role;
using BugFixer.Application.ViewModels.RolePermission;
using BugFixer.Domain.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugFixer.Application.Services.Interfaces
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleVM>> GetAllServiceAsync();
        Task<RoleVM> GetServiceAsync(int id);
        Task<int> AddServiceAsync(CreateRoleVM role);
        Task UpdateService(UpdateRoleVM role,List<int> permissions);
        Task<UpdateRoleVM> GetRoleInforForUpdate(int id);
        Task DeleteService(int id);
        Task<FilterRoleVM> FilterRole(FilterRoleVM filterRole);



        #region Permissions
        Task<IEnumerable<PermissionsVM>> PermissionListServiceAsync();
        Task AddRolePermissionServiceAsync(List<int> rolePermissions,int roleId);
        Task<IEnumerable<RolePermissionVM>> RolePermissionsServiceAsync(int roleId);


        #endregion
    }
}
