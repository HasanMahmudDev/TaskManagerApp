using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Domain.Enums;
using TaskStatus = TaskManager.Domain.Enums.TaskStatus;

namespace TaskManager.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; }           // Service title
        public string Description { get; set; }     // Service details
        public string CompanyName { get; set; }     // Client name
        public string Module { get; set; }          // Related module
        public string RequirementType { get; set; } // e.g., Bug, Feature
        public string AssignedTo { get; set; }      // Assigned user
        public string Tag { get; set; }             // e.g., TD 219-1

        public bool IsPreviousWork { get; set; }

        public DateTime CreateDate { get; set; }
        public TimeSpan EstdTime { get; set; }      // Estimated time
        public string FilePath { get; set; }        // File upload path

        public TaskPriority Priority { get; set; }
        public TaskStatus Status { get; set; }
    }
}
