using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskStage
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; } // e.g., ToDo, InProgress, Done
        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
