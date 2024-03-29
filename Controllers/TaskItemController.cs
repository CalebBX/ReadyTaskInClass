﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using ReadyTask.Data;
using ReadyTask.Hubs;
using ReadyTask.Models;
using ReadyTask.ViewModels;

namespace ReadyTask.Controllers
{
    public class TaskItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHubContext<NotificationHub> _hub;
        public TaskItemController(ApplicationDbContext context, IHubContext<NotificationHub> hub)
        {
            _context = context;
            _hub = hub;
        }
        // GET: TaskItem
        [Authorize]
        public ActionResult Index()
        {
            List<TaskItem> allTasks = _context.TaskItems.Include(t => t.AssignedUser).ToList();
            return View(allTasks);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Index(TaskItemFilters filters)
        {
            IQueryable<TaskItem> filteredTasks = _context.TaskItems.AsQueryable();
            if (!String.IsNullOrEmpty(filters.Search))
            {
                filteredTasks = filteredTasks.Where(t => t.Title.Contains(filters.Search));
            }
            TaskItemStatus status;
            if (Enum.TryParse(filters.Status, true, out status))
            {
                filteredTasks = filteredTasks.Where(t => t.StatusId == (int)status);
            }
            ViewBag.filters = filters;
            return View(filteredTasks.ToList());
        }

        // GET: TaskItem/Details/5
        [Authorize]
        public ActionResult Details(int id)
        {
            TaskItem task = _context.TaskItems
                .Include(t => t.AssignedUser)
                .Include(t => t.Replies)
                    .ThenInclude(r => r.ReadyTaskUser)
                .FirstOrDefault(t => t.Id == id);
            return View(task);
        }

        // GET: TaskItem/Create
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Create()
        {
            TaskItemCreate viewModel = new TaskItemCreate();
            viewModel.TaskItem = new TaskItem();
            viewModel.ReadyTaskUsers = _context.Users.ToList();
            return View(viewModel);
        }

        // POST: TaskItem/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Edit([Bind("Id,Title,Description,AssignedUserId,StatusId")] TaskItem task)
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
        [Authorize(Roles = "Admin, Manager")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TaskItem/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Manager")]
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
        [Authorize(Roles = "Admin, Manager, Dev")]
        public ActionResult CreateReply(string content, int taskId, int userId)
        {
            TaskReply reply = new TaskReply()
            {
                Content = content,
                TaskItemId = taskId,
                ReadyTaskUserId = userId,
                DateCreated = DateTime.Now
            };
            _context.TaskReplies.Add(reply);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = taskId });
        }
        [Authorize(Roles = "Admin, Manager, Dev")]
        public CreateReplyResponse CreateReplyAjax(string content, int taskId, int userId)
        {
            TaskReply reply = new TaskReply()
            {
                Content = content,
                TaskItemId = taskId,
                ReadyTaskUserId = userId,
                DateCreated = DateTime.Now
            };
            _context.TaskReplies.Add(reply);
            _context.SaveChanges();

            ReadyTaskUser user = _context.Users.Find(reply.ReadyTaskUserId);
            CreateReplyResponse response = new CreateReplyResponse()
            {
                Content = reply.Content,
                UserFirstName = user.FirstName,
                UserLastName = user.LastName,
                DateCreated = reply.DateCreated.Value.ToString("mm/dd/yy h:mm tt")
            };

            TaskItem task = _context.TaskItems.Find(taskId);

            if (task.AssignedUserId != null && task.AssignedUserId != 0)
            {
                Notification notification = new Notification()
                {
                    TaskId = taskId,
                    Message = $"<b>{user.FirstName} {user.LastName}</b> wrote a reply on one of your assigned tasks.",
                    ReadyTaskUserId = (int)task.AssignedUserId
                };
                _context.Notifications.Add(notification);
                _context.SaveChanges();
                _hub.Clients.All.SendAsync("ReceiveNotification", notification).Wait();
            }

            return response;
        }
        public List<Notification> GetNotificationsAjax(int userId)
        {
            return _context.Notifications.Where(n => n.ReadyTaskUserId == userId).ToList();
        }
        private bool TaskExists(int id)
        {
            return _context.TaskItems.Any(t => t.Id == id);
        }
    }
}