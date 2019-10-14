using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadyTask.Data;
using ReadyTask.Models;
using ReadyTask.ViewModels;

namespace ReadyTask.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TaskItemController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: TaskItem
        public ActionResult Index()
        {
            List<TaskItem> allTasks = _context.TaskItems.Include(t => t.AssignedUser).ToList();
            return View(allTasks);
        }

        // GET: TaskItem/Details/5
        public ActionResult Details(int id)
        {
            TaskItem task = _context.TaskItems
                .Include(t => t.AssignedUser)
                .Include(t => t.Replies)
                .FirstOrDefault(t => t.Id == id);
            return View(task);
        }

        // GET: TaskItem/Create
        public ActionResult Create()
        {
            TaskItemCreate viewModel = new TaskItemCreate();
            viewModel.ReadyTaskUsers = _context.Users.ToList();
            return View(viewModel);
        }

        // POST: TaskItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Title,Description,AssignedUserId")] TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        // GET: TaskItem/Edit/5
        public ActionResult Edit(int id)
        {
            TaskItemCreate viewModel = new TaskItemCreate();
            viewModel.ReadyTaskUsers = _context.Users.ToList();
            viewModel.TaskItem = _context.TaskItems.Find(id);
            return View(viewModel);
        }

        // POST: TaskItem/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Title,Description,AssignedUserId")] TaskItem task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            TaskItemCreate viewModel = new TaskItemCreate();
            viewModel.TaskItem = task;
            viewModel.ReadyTaskUsers = _context.Users.ToList();
            return View(viewModel);
        }

        // GET: TaskItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private bool TaskExists(int id)
        {
            return _context.TaskItems.Any(t=> t.Id == id);
        }
    }
}