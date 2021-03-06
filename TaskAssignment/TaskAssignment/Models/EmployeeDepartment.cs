using System;

namespace TaskAssignment.Models
{
    public class EmployeeDepartment
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public virtual Employee Employee { get; set; }

        public int DeptID { get; set; }

        public virtual Department Department { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Description { get; set; }
    }
}
