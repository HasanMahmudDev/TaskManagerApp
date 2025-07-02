using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class TaskStage
    {
        [Key]
        public int TaskStageId { get; set; }

        [Required]
        [StringLength(100)]
        public string TaskStageName { get; set; } // Example: ToDo, InProgress, Done

        // Navigation property (linked TaskItems)
        public virtual ICollection<TaskItem> TaskItems { get; set; } = new List<TaskItem>();
    }
}
