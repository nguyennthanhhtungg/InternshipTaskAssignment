using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment2.Models;

namespace TaskAssignment2.Services
{
    class TaskAssignment1API : ITaskAssignment1API
    {
        public async Task DisplayEmployeeListOnConsole(string uri)
        {
            List<Employee> employeeList = new List<Employee>();

            //Get EmployeeList from Task Assignment 1 API
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(uri))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    employeeList = JsonConvert.DeserializeObject<List<Employee>>(apiResponse);
                }
            }

            foreach (var emp in employeeList)
            {
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine($"EmployeeId: {emp.EmployeeId}");
                Console.WriteLine($"EmployeeNo: {emp.EmployeeNo}");
                Console.WriteLine($"FirstName: {emp.FirstName}");
                Console.WriteLine($"LastName: {emp.LastName}");
                Console.WriteLine($"DateOfBirth: {emp.DateOfBirth}");
                Console.WriteLine($"Gender: {emp.Gender}");
                Console.WriteLine($"MobileNumber: {emp.MobileNumber}");
                Console.WriteLine($"Address: {emp.Address}");
                Console.WriteLine($"Email: {emp.Email}");
                Console.WriteLine($"MarriageStatus: {emp.MarriageStatus}");
                Console.WriteLine($"Nationality: {emp.Nationality}");
                Console.WriteLine($"IsActived: {emp.IsActived}");
                Console.WriteLine($"DeptId: {emp.DeptId}");
                Console.WriteLine("--------------------------------------------------");
            }
        }
    }
}
