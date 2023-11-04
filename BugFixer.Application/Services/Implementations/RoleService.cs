using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Role;
using BugFixer.Data.Repository;
using BugFixer.Domain.Interfaces;
using BugFixer.Domain.Models.Role;
using BugFixer.Domain.Models.User;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddServiceAsync(CreateRoleVM role)
        {
            Role newRole = new Role()
            {
                Title = role.Title,
                Name = role.Name,

            };

            await _roleRepository.AddAsync(newRole);
            await _roleRepository.SaveChangeAsync();
        }

        public async void DeleteService(int id)
        {
            Role role = await _roleRepository.GetAsync(id);

            _roleRepository.Delete(role);
            _roleRepository.SaveChangeAsync();
        }

        public async Task<FilterRoleVM> FilterRole(FilterRoleVM filterRole)
        {
            IQueryable<Role> query = _roleRepository.GetQueryableRole();

            if (!string.IsNullOrEmpty(filterRole.Title))
            {
                query = query.Where(u => EF.Functions.Like(u.Title, $"%{filterRole.Title.Trim().ToLower()}%"));
            }
            if (!string.IsNullOrEmpty(filterRole.Name))
            {
                query = query.Where(u => EF.Functions.Like(u.Name, $"%{filterRole.Name.Trim().ToLower()}%"));
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
                Name = r.Name,
                CreateDate = r.CreateDate,
                Id = r.Id,
            }).ToList();
        }

        public async Task<RoleVM> GetServiceAsync(int id)
        {
            Role role = await _roleRepository.GetAsync(id);

            return new RoleVM()
            {
                Title = role.Title,
                Name = role.Name,
                CreateDate = role.CreateDate,
                Id = role.Id,
            };

        }

        public async Task UpdateService(UpdateRoleVM role)
        {
            Role getRole = await _roleRepository.GetAsync(role.Id);

            getRole.Title = role.Title;
            getRole.Name = role.Name;

            _roleRepository.Update(getRole);
            await _roleRepository.SaveChangeAsync();

        }
    }
}
