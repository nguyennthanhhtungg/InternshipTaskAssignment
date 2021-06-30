using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment2.Models;
using TaskAssignment2.Repositories;

namespace TaskAssignment2.Services
{
    class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task ExportEmployeesWithIsActivedFalseToCSVFile()
        {
            var path = ConfigurationManager.AppSettings["ExportFolderPath"];

            //Get all employees
            var employeesWithIsActivedFalse = await employeeRepository.GetAllEmployeesWithIsActivedFalse();


            var lines = new List<string>();

            //Insert Column Names
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(Employee)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);


            //Insert Column Values
            foreach (var employee in employeesWithIsActivedFalse)
            {
                StringBuilder employeeLine = new StringBuilder();

                foreach (PropertyInfo prop in employee.GetType().GetProperties())
                {
                    if(prop.GetValue(employee, null) == null)
                    {
                        employeeLine.Append("NULL");
                    }
                    else
                    {
                        employeeLine.Append(String.Format("\"{0}\"", prop.GetValue(employee, null)));
                    }

                    employeeLine.Append(",");
                }

                lines.Add(employeeLine.ToString());
            }

            File.WriteAllLines(path + "EmployeesWithIsActivedFalse.csv", lines.ToArray());
        }
    }
}
