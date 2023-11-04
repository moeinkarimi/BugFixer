using BugFixer.Application.ViewModels.Role;
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
        Task AddServiceAsync(CreateRoleVM role);
        Task UpdateService(UpdateRoleVM role);
        void DeleteService(int id);
        Task<FilterRoleVM> FilterRole(FilterRoleVM filterRole);
    }
}
