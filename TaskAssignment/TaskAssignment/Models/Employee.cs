using System;
using System.Collections.Generic;

#nullable disable

namespace TaskAssignment.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string MarriageStatus { get; set; }

        public string Nationality { get; set; }

        public bool? IsActived { get; set; }

        public int? DeptId { get; set; }

        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
