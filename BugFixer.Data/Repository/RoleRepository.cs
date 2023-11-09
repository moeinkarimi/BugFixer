using BugFixer.Data.Context;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Role;
using Microsoft.EntityFrameworkCore;

namespace BugFixer.Data.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly BugFixerDBContext _ctx;
        public RoleRepository(BugFixerDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task AddAsync(Role role)
        {
           await _ctx.Roles.AddAsync(role);
         
        }

        public void  Delete(Role role)
        {
            _ctx.Roles.Remove(role);
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _ctx.Roles.ToListAsync();
        }

        public async Task<Role> GetAsync(int id)
        {
            return await _ctx.Roles.FirstOrDefaultAsync(r => r.Id == id);
        }

        public IQueryable<Role> GetQueryableRole()
        {
            return _ctx.Roles.AsQueryable();
        }


        public async Task SaveChangeAsync()
        {
            await _ctx.SaveChangesAsync();
        }

        public void Update(Role role)
        {
            _ctx.Roles.Update(role);
        }


        #region Permissions
        public async Task<IEnumerable<Permission>> PermissionListAsync()
        {
            return await _ctx.Persmissions.ToListAsync();
        }

        public async Task AddRolePermissionAsync(RolePermission rolePermission)
        {
            await _ctx.RolePermissions.AddAsync(rolePermission);
        }

        public async Task<IEnumerable<RolePermission>> rolePermissionsAsync(int roleId)
        {
           return await _ctx.RolePermissions.Where(rp=> rp.RoleId == roleId).ToListAsync();
        }

        public void DeleteRolePermissionAsync(RolePermission rolePermission)
        {
            _ctx.RolePermissions.Remove(rolePermission);
        }
        #endregion
    }
}
