using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.Role;
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


        [HttpGet("admin/role-add")]
        public async Task<IActionResult> Add()
        {
            ViewBag.PermissionList = await _roleService.PermissionListServiceAsync();
            return View();
        }

        [HttpPost("admin/role-add")]
        public async Task<IActionResult> Add(CreateRoleVM createRole, List<int> permissions)
        {

            if (!ModelState.IsValid)
            {
                return View(createRole);
            }
            int roleId = await _roleService.AddServiceAsync(createRole);
            await _roleService.AddRolePermissionServiceAsync(permissions, roleId);
            return RedirectToAction("Index");
        }

        [HttpGet("admin/role-update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.RolePermissions = await _roleService.RolePermissionsServiceAsync(id);
            ViewBag.PermissionList = await _roleService.PermissionListServiceAsync();

            UpdateRoleVM roleInfor = await _roleService.GetRoleInforForUpdate(id);
            return View(roleInfor);
        }

        [HttpPost("admin/role-update/{id}")]
        public async Task<IActionResult> Update(UpdateRoleVM updateRole, List<int> permissions)
        {
            if (!ModelState.IsValid)
            {
                return View(updateRole);
            }
            await _roleService.UpdateService(updateRole, permissions);
            return RedirectToAction("Index");
        }


        [HttpGet("admin/role-show/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            RoleVM roleInfor = await _roleService.GetServiceAsync(id);
            return View(roleInfor);
        }
        [HttpGet("admin/role-delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleService.DeleteService(id);
            return Json(new { status = "success" });
        }
    }
}
