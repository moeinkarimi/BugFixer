﻿using BugFixer.Application.Services.Interfaces;
using BugFixer.Application.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace BugFixer.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
 
        private readonly FilterUsersViewModel filterUsers;
        public UserController(IUserService userService)
        {
            _userService = userService;
            filterUsers = new FilterUsersViewModel();
           
        }
        [HttpGet("admin/user-list")]
        public async Task<IActionResult> Index()
        {
            FilterUsersViewModel userLIst = await _userService.FilterUser(filterUsers);
            return View(userLIst);
        }
        [HttpGet]
        public async Task<IActionResult> FilterUsersAjax(FilterUsersViewModel filterUsers)
        {
            return RedirectToAction("Index", filterUsers);
        }

        [HttpGet("admin/create-user")]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost("admin/create-user")]
        public async Task<IActionResult> Create(CreateUserVM createUser)
        {
            if (!ModelState.IsValid)
            {
                return View(createUser);
            }

            await _userService.CreateServiceAsync(createUser);
            return RedirectToAction("Index");
        }


        [HttpGet("admin/update-user/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            UpdateUserVM userInfor = await _userService.GetUserInforForUpdate(id);
            return View(userInfor);
        }


        [HttpPost("admin/update-user/{id}")]
        public async Task<IActionResult> Update(UpdateUserVM updateUserVM)
        {

            if (!ModelState.IsValid)
            {
                return View(updateUserVM);
            }

            await _userService.UpdateServiceAsync(updateUserVM);
            return RedirectToAction("Index");
        }


        [HttpGet("admin/show-user/{id}")]
        public async Task<IActionResult> Show(int id)
        {
            UserVM userInfor = await _userService.GetServiceAsync(id);
            return View(userInfor);
        }


        [HttpGet("admin/delete-user/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteServiceAsync(id);
            return Json(new { status = "success" });
        }



    }
}
