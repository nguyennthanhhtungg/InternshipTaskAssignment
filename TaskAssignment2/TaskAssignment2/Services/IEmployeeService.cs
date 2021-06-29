using System;
using System.Collections.Generic;
using System.Text;

namespace TaskAssignment2.Services
{
    public interface IEmployeeService
    {
        void ExportEmployeesWithIsActivedFalseToCSVFile();
    }
}
