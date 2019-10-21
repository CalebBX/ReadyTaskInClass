using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadyTask.ViewModels
{
    public class CreateReplyResponse
    {
        public string Content { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string DateCreated { get; set; }
    }
}
