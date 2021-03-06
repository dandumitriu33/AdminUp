﻿using AdminUp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminUp.Controllers
{
    //[Authorize(Roles = "SuperAdmin")]

    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AdministrationController(RoleManager<IdentityRole> roleManager,
                                        UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName
                };
                IdentityResult result = await _roleManager.CreateAsync(identityRole);

                if (result.Succeeded)
                {
                    return RedirectToAction("listroles", "administration");
                }

                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(string email)
        {
            if (email==null)
            {
                return View();
            }
            List<UserRoleModel> result = new List<UserRoleModel>();
            var user = await _userManager.FindByEmailAsync(email);

            result.Add(new UserRoleModel()
            {
                User = user,
                RoleId = "",
                RoleName = ""
            });
            if (await _userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                result.Add(new UserRoleModel()
                {
                    User = user,
                    RoleId = "",
                    RoleName = "SuperAdmin"
                });
            }
            if (await _userManager.IsInRoleAsync(user, "BuildingAdmin"))
            {
                result.Add(new UserRoleModel()
                {
                    User = user,
                    RoleId = "",
                    RoleName = "BuildingAdmin"
                });
            }
            if (await _userManager.IsInRoleAsync(user, "AppartmentOwner"))
            {
                result.Add(new UserRoleModel()
                {
                    User = user,
                    RoleId = "",
                    RoleName = "AppartmentOwner"
                });
            }
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> MakeSuperAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRoleAsync(user, "SuperAdmin");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSuperAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.RemoveFromRoleAsync(user, "SuperAdmin");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }

        [HttpPost]
        public async Task<IActionResult> MakeBuildingAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRoleAsync(user, "BuildingAdmin");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveBuildingAdmin(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.RemoveFromRoleAsync(user, "BuildingAdmin");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }

        [HttpPost]
        public async Task<IActionResult> MakeAppartmentOwner(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.AddToRoleAsync(user, "AppartmentOwner");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }

        [HttpPost]
        public async Task<IActionResult> RemoveAppartmentOwner(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.RemoveFromRoleAsync(user, "AppartmentOwner");

            if (result.Succeeded)
            {
                return RedirectToAction("ManageUserRoles", "administration", new { email = email });
            }
            return RedirectToAction("ManageUserRoles", "administration", new { email = email });
        }
    }
}
