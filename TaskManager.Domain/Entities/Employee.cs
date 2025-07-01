using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
        public DateTime JoiningDate { get; set; }

        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
    }

}
