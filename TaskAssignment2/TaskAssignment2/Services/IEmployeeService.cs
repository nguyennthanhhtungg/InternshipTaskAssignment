using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskAssignment2.Services
{
    public interface IEmployeeService
    {
        Task ExportEmployeesWithIsActivedFalseToCSVFile();
    }
}
