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


        [HttpGet("admin/role-add")]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost("admin/role-add")]
        public async Task<IActionResult> Add(CreateRoleVM createRole)
        {
            if (!ModelState.IsValid)
            {
                return View(createRole);
            }
            await _roleService.AddServiceAsync(createRole);
            return RedirectToAction("Index");
        }

        [HttpGet("admin/role-update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            UpdateRoleVM roleInfor = await _roleService.GetRoleInforForUpdate(id);
            return View(roleInfor);
        }

        [HttpPost("admin/role-update/{id}")]
        public async Task<IActionResult> Update(UpdateRoleVM updateRole)
        {
            if (!ModelState.IsValid)
            {
                return View(updateRole);
            }
            await _roleService.UpdateService(updateRole);
            return RedirectToAction("Index");
        }


        [HttpGet("admin/role-show/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            RoleVM roleInfor = await _roleService.GetServiceAsync(id);
            return View(roleInfor);
        }

        [HttpGet("admin/role-delete/{id}")]
        public  async Task<IActionResult> Delete(int id)
        {
           await _roleService.DeleteService(id);
            return Json(new { status = "success" });


        }


    }
}
