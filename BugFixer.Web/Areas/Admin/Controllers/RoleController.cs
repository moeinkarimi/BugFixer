using BugFixer.Application.Services.Implementations;
using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Role;
using BugFixer.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        #region Fields
        private readonly IRoleService _roleService;
        private readonly FilterRoleVM _filterRoleVM;
        #endregion

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
            _filterRoleVM = new FilterRoleVM();
        }
        [HttpGet("admin/role-list/{filterRoles?}")]
        public async Task<IActionResult> Index(FilterRoleVM? filterRoles)
        {
            FilterRoleVM filteredRoles = await _roleService.FilterRole(filterRoles);
            return View(filteredRoles);
           
        }

        [HttpGet]
        public async Task<IActionResult> FilterRolesAjax(FilterRoleVM filterRoles)
        {
            return RedirectToAction($"Index{filterRoles}");
        }
    }
}
