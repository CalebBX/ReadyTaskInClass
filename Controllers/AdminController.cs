using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReadyTask.Data;
using ReadyTask.Models;
using ReadyTask.ViewModels;

namespace ReadyTask.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ReadyTaskUser> _userManager;
        public AdminController(ApplicationDbContext context, UserManager<ReadyTaskUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }
        public async Task<IActionResult> UpdateUserRoles(UserRoleAssignment[] userRoleAssignments)
        {
            foreach (UserRoleAssignment assignment in userRoleAssignments)
            {
                ReadyTaskUser user = _context.Users.Find(assignment.UserId);
                await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                if (!String.IsNullOrEmpty(assignment.RoleName))
                {
                    await _userManager.AddToRoleAsync(user, assignment.RoleName);
                }
                
            }
            return RedirectToAction(nameof(Index));
        }
    }
    public class UserRoleAssignment
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}