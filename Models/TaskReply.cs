using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyTask.Models
{
    public class TaskReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int ReadyTaskUserId { get; set; }
        [ForeignKey("ReadyTaskUserId")]
        public ReadyTaskUser ReadyTaskUser { get; set; }
        public DateTime? DateCreated { get; set; }
        public int TaskItemId { get; set; }
    }
}
