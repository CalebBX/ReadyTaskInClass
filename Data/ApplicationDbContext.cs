using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadyTask.Models;

namespace ReadyTask.Data
{
    public class ApplicationDbContext : IdentityDbContext<ReadyTaskUser, ReadyTaskUserRole, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TaskReply> TaskReplies { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Seeding Users
            var hasher = new PasswordHasher<ReadyTaskUser>();
            builder.Entity<ReadyTaskUser>().HasData(
                new ReadyTaskUser
                {
                    Id = 100,
                    UserName = "test@test.com",
                    Email = "test@test.com",
                    NormalizedEmail = "test@test.com".ToUpper(),
                    NormalizedUserName = "test@test.com".ToUpper(),
                    FirstName = "John",
                    LastName = "Doe",
                    TwoFactorEnabled = false,
                    EmailConfirmed = true,
                    SecurityStamp = string.Empty,
                    PasswordHash = hasher.HashPassword(null, "password")
                }
                );

            //Seeding Task Items
            builder.Entity<TaskItem>().HasData(
                new TaskItem[]
                {
                    new TaskItem
                    {
                        Id = 100,
                        Title = "Test Task 1",
                        Description  = "Description for Task 1",
                        AssignedUserId = null
                    },
                    new TaskItem
                    {
                        Id = 101,
                        Title = "Test Task 2",
                        Description  = "Description for Task 2",
                        AssignedUserId = null
                    },
                    new TaskItem
                    {
                        Id = 102,
                        Title = "Test Task 3",
                        Description  = "Description for Task 3",
                        AssignedUserId = 100
                    },
                }
                );
        }
    }
}
