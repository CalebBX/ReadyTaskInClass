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
        public DbSet<Notification> Notifications { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ReadyTaskUserRole>().HasData(
                new ReadyTaskUserRole[]
                {
                    new ReadyTaskUserRole
                    {
                        Id = 1,
                        Name = "Admin",
                        NormalizedName = "Admin".ToUpper()
                    },
                    new ReadyTaskUserRole
                    {
                        Id = 2,
                        Name = "Manager",
                        NormalizedName = "Manager".ToUpper()
                    },
                    new ReadyTaskUserRole
                    {
                        Id = 3,
                        Name = "Dev",
                        NormalizedName = "Dev".ToUpper()
                    }
                }
                );

            //Seeding Users
            var hasher = new PasswordHasher<ReadyTaskUser>();
            builder.Entity<ReadyTaskUser>().HasData(
                new ReadyTaskUser
                {
                    Id = 100,
                    UserName = "user@test.com",
                    Email = "user@test.com",
                    NormalizedEmail = "user@test.com".ToUpper(),
                    NormalizedUserName = "user@test.com".ToUpper(),
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
                        AssignedUserId = null,
                        StatusId = 0
                    },
                    new TaskItem
                    {
                        Id = 101,
                        Title = "Test Task 2",
                        Description  = "Description for Task 2",
                        AssignedUserId = null,
                        StatusId = 1
                    },
                    new TaskItem
                    {
                        Id = 102,
                        Title = "Test Task 3",
                        Description  = "Description for Task 3",
                        AssignedUserId = 100,
                        StatusId = 2
                    },
                }
                );
        }
    }
}
