using ReadyTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyTask.ViewModels
{
    public class AdminUserRoles
    {
        public List<ReadyTaskUser> ReadyTaskUsers { get; set; }
        public List<ReadyTaskUserRole> ReadyTaskUserRoles { get; set; }
    }
}
