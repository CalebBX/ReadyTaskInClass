using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadyTask.Data;
using ReadyTask.Models;
using ReadyTask.ViewModels;

namespace ReadyTask.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            AdminUserRoles viewModel = new AdminUserRoles();
            viewModel.ReadyTaskUsers = _context.Users.ToList();
            viewModel.ReadyTaskUserRoles = _context.Roles.ToList();
            return View(viewModel);
        }
    }
}