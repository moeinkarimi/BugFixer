using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Role;
using BugFixer.Application.ViewModels.RolePermission;
using BugFixer.Data.Repository;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Role;
using BugFixer.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Web.Mvc;

namespace BugFixer.Application.Services.Implementations
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<int> AddServiceAsync(CreateRoleVM role)
        {
            Role newRole = new Role()
            {
                Title = role.Title,

            };

            await _roleRepository.AddAsync(newRole);
            await _roleRepository.SaveChangeAsync();

            return newRole.Id;
        }

        public async Task DeleteService(int id)
        {
            Role role = await _roleRepository.GetAsync(id);

            IEnumerable<RolePermission> rolePermissionList = await _roleRepository.rolePermissionsAsync(role.Id);

            #region Remove Role Permissions
            if (!rolePermissionList.IsNullOrEmpty())
            {
                foreach (RolePermission item in rolePermissionList)
                {
                    _roleRepository.DeleteRolePermissionAsync(item);
                }
                await _roleRepository.SaveChangeAsync();
            }

            #endregion

            _roleRepository.Delete(role);
            await _roleRepository.SaveChangeAsync();
        }

        public async Task<FilterRoleVM> FilterRole(FilterRoleVM filterRole)
        {
            IQueryable<Role> query = _roleRepository.GetQueryableRole();

            if (!string.IsNullOrEmpty(filterRole.Title))
            {
                query = query.Where(u => EF.Functions.Like(u.Title, $"%{filterRole.Title.Trim().ToLower()}%"));
            }


            await filterRole.Paging(query);

            return filterRole;
        }

        public async Task<IEnumerable<RoleVM>> GetAllServiceAsync()
        {
            IEnumerable<Role> roleList = await _roleRepository.GetAllAsync();
            return roleList.Select(r => new RoleVM()
            {
                Title = r.Title,
                CreateDate = r.CreateDate,
                Id = r.Id,
            }).ToList();
        }

        public async Task<UpdateRoleVM> GetRoleInforForUpdate(int id)
        {
            Role role = await _roleRepository.GetAsync(id);

            return new UpdateRoleVM()
            {
                Title = role.Title,

                Id = role.Id,
            };
        }

        public async Task<RoleVM> GetServiceAsync(int id)
        {
            Role role = await _roleRepository.GetAsync(id);

            return new RoleVM()
            {
                Title = role.Title,
                CreateDate = role.CreateDate,
                Id = role.Id,
            };

        }


        public async Task UpdateService(UpdateRoleVM role, List<int> permissions)
        {
            Role getRole = await _roleRepository.GetAsync(role.Id);

            getRole.Title = role.Title;

            IEnumerable<RolePermission> rolePermissionList = await _roleRepository.rolePermissionsAsync(role.Id);

            #region Remove Role Permissions
            if (!rolePermissionList.IsNullOrEmpty())
            {
                foreach (RolePermission permission in rolePermissionList)
                {
                    _roleRepository.DeleteRolePermissionAsync(permission);
                }
                await _roleRepository.SaveChangeAsync();
            }

            #endregion


            #region Add Role Permissions
            await AddRolePermissionServiceAsync(permissions, role.Id);
            await _roleRepository.SaveChangeAsync();
            #endregion



            _roleRepository.Update(getRole);
            await _roleRepository.SaveChangeAsync();

        }


        #region Permissions

        public async Task<IEnumerable<PermissionsVM>> PermissionListServiceAsync()
        {
            IEnumerable<Permission> permissions = await _roleRepository.PermissionListAsync();

            return permissions.Select(p => new PermissionsVM()
            {
                Id = p.Id,
                Title = p.Title,
            }).ToList();
        }

        public async Task AddRolePermissionServiceAsync(List<int> rolePermissions, int roleId)
        {
            foreach (var item in rolePermissions)
            {
                RolePermission rolePermission = new RolePermission()
                {
                    RoleId = roleId,
                    PersmissionId = item
                };

                await _roleRepository.AddRolePermissionAsync(rolePermission);
            }
            await _roleRepository.SaveChangeAsync();
        }

        public async Task<IEnumerable<RolePermissionVM>> RolePermissionsServiceAsync(int roleId)
        {
            IEnumerable<RolePermission> rolePermissions = await _roleRepository.rolePermissionsAsync(roleId);

            return rolePermissions.Select(p => new RolePermissionVM()
            {
                PersmissionId = p.PersmissionId,

            }).ToList();
        }
        #endregion
    }
}
