using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Comment
    {

        [Key]
        public int CommentId { get; set; }
        [Required]
        [ForeignKey("TaskItem")]
        public int TaskItemId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string CommentText { get; set; }
        [Required]
        public DateTime CommentDate { get; set; } = DateTime.Now;
        public virtual TaskItem TaskItems { get; set; }
        public virtual User User { get; set; }
    }

}
