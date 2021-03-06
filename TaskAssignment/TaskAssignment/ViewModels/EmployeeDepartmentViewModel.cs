using System;

namespace TaskAssignment.ViewModels
{
    public class EmployeeDepartmentViewModel
    {
        public int ID { get; set; }

        public int EmployeeID { get; set; }

        public int DeptID { get; set; }

        public DateTime StartDate { get; set; }

        public string Description { get; set; }
    }
}
