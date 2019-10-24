﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyTask.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? AssignedUserId { get; set; }
        [ForeignKey("AssignedUserId")]
        public ReadyTaskUser AssignedUser { get; set; }
        public List<TaskReply> Replies { get; set; }
        public int StatusId { get; set; }

        public TaskItem()
        {
            this.StatusId = 1;
        }
    }
}
