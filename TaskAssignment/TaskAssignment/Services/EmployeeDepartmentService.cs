using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;

namespace TaskAssignment.Services
{
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {
        private readonly IEmployeeDepartmentRepository employeeDepartmentRepository;

        public EmployeeDepartmentService(IEmployeeDepartmentRepository employeeDepartmentRepository)
        {
            this.employeeDepartmentRepository = employeeDepartmentRepository;
        }

        public async Task<EmployeeDepartment> Add(EmployeeDepartment employeeDepartment)
        {
            //Get Lastest EmployeeDepartment By EmployeeId
            var lastestEmployeeDepartment = await employeeDepartmentRepository.GetLastestEmployeeDepartmentByEmployeeId(employeeDepartment.EmployeeID);

            if (lastestEmployeeDepartment != null)
            {
                //Check whether StartDate's next EmployeeDepartment is higher than previous one or not
                //Check whether DeptID's next EmployeeDepartment is as euqal as previous one or not
                if (employeeDepartment.StartDate.Date <= lastestEmployeeDepartment.StartDate.Date || employeeDepartment.DeptID == lastestEmployeeDepartment.DeptID)
                {
                    return null;
                }
                else
                {
                    //Update EndDate of previous EmployeeDepartment
                    lastestEmployeeDepartment.EndDate = employeeDepartment.StartDate.AddDays(-1);
                    await employeeDepartmentRepository.Update(lastestEmployeeDepartment);
                }
            }

            await employeeDepartmentRepository.Add(employeeDepartment);
            return employeeDepartment;
        }

        public async Task<List<EmployeeDepartment>> GetAll()
        {
            var employeeDepartments = await employeeDepartmentRepository.GetAll();
            return employeeDepartments.ToList();
        }

        public async Task<EmployeeDepartment> GetById(int id)
        {
            var employeeDepartment = await employeeDepartmentRepository.GetById(id);
            return employeeDepartment;
        }


        public async Task<List<EmployeeDepartment>> GetEmployeeDepartmentListByEmployeeId(int employeeId)
        {
            return await employeeDepartmentRepository.GetEmployeeDepartmentListByEmployeeId(employeeId);
        }

        public async Task<EmployeeDepartment> Update(EmployeeDepartment employeeDepartment)
        {
            //Get Lastest Completed EmployeeDepartment By EmployeeId
            var lastestEmployeeDepartment = await employeeDepartmentRepository.GetLastestCompletedEmployeeDepartmentByEmployeeId(employeeDepartment.EmployeeID);

            if (lastestEmployeeDepartment != null)
            {
                //Check whether StartDate's next EmployeeDepartment is higher than previous one or not
                //Check whether DeptID's next EmployeeDepartment is as euqal as previous one or not
                if (employeeDepartment.StartDate.Date <= lastestEmployeeDepartment.StartDate.Date || employeeDepartment.DeptID == lastestEmployeeDepartment.DeptID)
                {
                    return null;
                }
                else
                {
                    //Update EndDate of previous EmployeeDepartment
                    lastestEmployeeDepartment.EndDate = employeeDepartment.StartDate.AddDays(-1);
                    await employeeDepartmentRepository.Update(lastestEmployeeDepartment);
                }
            }

            await employeeDepartmentRepository.Update(employeeDepartment);
            return employeeDepartment;
        }
    }
}
