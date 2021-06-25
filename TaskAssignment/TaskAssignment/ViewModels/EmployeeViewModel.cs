using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAssignment.ViewModels
{
    public class EmployeeViewModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please type EmployeeNo!")]
        public string EmployeeNo { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "Please type Gender!")]
        public string Gender { get; set; }

        public string MobileNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string MarriageStatus { get; set; }

        public string Nationality { get; set; }

        public bool? IsActived { get; set; }

        public int? DeptId { get; set; }

        //public virtual DepartmentViewModel Dept { get; set; }
    }
}
