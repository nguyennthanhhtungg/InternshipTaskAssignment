using System;
using System.Collections.Generic;

#nullable disable

namespace TaskAssignment.Models
{
    public class Department
    {
        //public Department()
        //{
        //    EmployeeDepartments = new HashSet<EmployeeDepartments>();
        //}

        public int DeptId { get; set; }

        public string DeptName { get; set; }

        public string DeptLocation { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
