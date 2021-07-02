﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskAssignment.Models;

namespace TaskAssignment.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetById(int id);

        Task<List<Employee>> GetAll();

        Task<Employee> Add(Employee employee);

        Task<Employee> Update(Employee employee);
    }
}
