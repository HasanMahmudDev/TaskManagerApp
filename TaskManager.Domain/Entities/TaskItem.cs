using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class TaskItem
    {
        public int TaskId { get; set; }
        public int ProjectId { get; set; }
        public int AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public string TaskTitle { get; set; }
        public string Description { get; set; }
        public Priority Priority { get; set; }
        public int StatusId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public virtual Project Project { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual User Creator { get; set; }
        public virtual TaskStage Status { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

}
