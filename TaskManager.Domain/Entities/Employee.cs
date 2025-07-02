using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Employee
    {

        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        [Required]
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public DateTime JoiningDate { get; set; }
        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<TaskItem> AssignedTasks { get; set; }
    }

}
