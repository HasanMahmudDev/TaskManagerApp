using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManager.Domain.Enums;

namespace TaskManager.Domain.Entities
{
    public class TaskItem
    {
        [Key]
        public int TaskItemId { get; set; }

        [Required]
        public int ProjectId { get; set; }

        [Required]
        public int AssignedTo { get; set; }  // FK to Employee

        [Required]
        public int AssignedBy { get; set; }  // FK to User

        [Required]
        [StringLength(200)]
        public string TaskTitle { get; set; }

        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [Required]
        public int TaskStageId { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        // 🔗 Navigation Properties
        public virtual Project Project { get; set; }

        [ForeignKey(nameof(AssignedTo))]
        public virtual Employee AssignedEmployee { get; set; }

        [ForeignKey(nameof(AssignedBy))]
        public virtual User AssignedUser { get; set; }

        [ForeignKey(nameof(TaskStageId))] // ✅ সঠিকভাবে যুক্ত করলাম
        public virtual TaskStage TaskStage { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }


    }

}
