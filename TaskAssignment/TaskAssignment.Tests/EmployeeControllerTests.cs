using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskAssignment.Controllers;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.ViewModels;
using Xunit;

namespace TaskAssignment.Tests
{
    public class EmployeeControllerTests
    {
        Mock<IEmployeeRepository> mockEmployeeRepository = new Mock<IEmployeeRepository>();
        Mock<IMapper> mockMapper = new Mock<IMapper>();


        [Fact]
        public async Task GetAll_NoExistAnyEmployess_GetEmptyEmployeeList()
        {
            //Arrange
            mockEmployeeRepository.Setup(x => x.GetAll()).ReturnsAsync(() => null);
            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.GetAll();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Null(okObjectResult.Value);
        }

        [Fact]
        public async Task GetAll_ExistEmployess_GetEmployeeList()
        {
            //Arrange
            var dummyEmployees = new Employee[2]
            {
                new Employee
                {
                    EmployeeId = 1,
                    EmployeeNo = "123",
                    FirstName = "Tùng",
                    LastName = "Nguyễn",
                    DateOfBirth = new DateTime(1999, 08, 18),
                    Gender = "F",
                    MobileNumber = "0868042318",
                    Address = "HCM City",
                    Email = "tung-thanh.nguyen@capgemine.com",
                    MarriageStatus = "Single",
                    Nationality = "Vietnam",
                    IsActived = true,
                    DeptId = null,
                    Dept = null
                },
                new Employee
                {
                    EmployeeId = 2,
                    EmployeeNo = "abc",
                    FirstName = "Tùng",
                    LastName = "Nguyễn",
                    DateOfBirth = new DateTime(1999, 08, 18),
                    Gender = "F",
                    MobileNumber = "0868042318",
                    Address = "HCM City",
                    Email = "nguyenthanhtung884318@capgemine.com",
                    MarriageStatus = "Single",
                    Nationality = "Vietnam",
                    IsActived = false,
                    DeptId = null,
                    Dept = null
                }
            };

            mockEmployeeRepository.Setup(x => x.GetAll())
                .ReturnsAsync(dummyEmployees);

            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.GetAll();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(dummyEmployees, okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_NoExistEmployeeId_204NoContent()
        {
            //Arrange
            mockEmployeeRepository.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Employee)null);
            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.GetById(It.IsAny<int>());

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((Employee)null, okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ExistEmployeeId_EmployeeDetail()
        {
            var dummyEmployee = new Employee
            {
                EmployeeId = 1,
                EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemine.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null,
                Dept = null
            };

            //Arrange
            mockEmployeeRepository.Setup(x => x.GetById(1))
                .ReturnsAsync(dummyEmployee);

            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.GetById(1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(dummyEmployee, okObjectResult.Value);
        }

        [Fact]
        public async Task Add_InvalidEmployeeInfo_BadRequestObjectResult()
        {
            var dummyEmployeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 1,
                EmployeeNo = null,
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemine.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null
            };

            //Arrange
            mockMapper.Setup(x => x.Map<Employee>(It.IsAny<EmployeeViewModel>()));
            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);
            employeeController.ModelState.AddModelError("EmployeeNo", "EmployeeNo is required");

            //Act
            var result = await employeeController.Add(dummyEmployeeViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Add_ValidEmployeeInfo_OkObjectResult()
        {
            var dummyEmployee = new Employee
            {
                EmployeeId = 0,
                EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemini.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null,
                Dept = null
            };

            var dummyEmployeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 0,
                EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemini.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null
            };

            //Arrange
            mockEmployeeRepository.Setup(x => x.Add(dummyEmployee));
            mockMapper.Setup(x => x.Map<Employee>(It.IsAny<EmployeeViewModel>()))
                .Returns(() => dummyEmployee);

            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.Add(dummyEmployeeViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(dummyEmployee, okObjectResult.Value);
        }

        [Fact]
        public async Task Update_InvalidEmployeeInfo_BadRequestObjectResult()
        {
            var dummyEmployeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 1,
                //EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemine.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null,
            };

            //Arrange
            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);
            employeeController.ModelState.AddModelError("EmployeeNo", "EmployeeNo is required");

            //Act
            var result = await employeeController.Update(dummyEmployeeViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_ValidEmployeeInfo_OkObjectResult()
        {
            var dummyEmployee = new Employee
            {
                EmployeeId = 0,
                EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn Thanh",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemini.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null,
                Dept = null
            };

            var dummyEmployeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 0,
                EmployeeNo = "123",
                FirstName = "Tùng",
                LastName = "Nguyễn",
                DateOfBirth = new DateTime(1999, 08, 18),
                Gender = "F",
                MobileNumber = "0868042318",
                Address = "HCM City",
                Email = "tung-thanh.nguyen@capgemini.com",
                MarriageStatus = "Single",
                Nationality = "Vietnam",
                IsActived = true,
                DeptId = null
            };

            //Arrange
            mockEmployeeRepository.Setup(x => x.Update(dummyEmployee));
            mockMapper.Setup(x => x.Map<Employee>(It.IsAny<EmployeeViewModel>()))
                .Returns(() => dummyEmployee);

            EmployeeController employeeController = new EmployeeController(mockEmployeeRepository.Object, mockMapper.Object);

            //Act
            var result = await employeeController.Update(dummyEmployeeViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(dummyEmployee, okObjectResult.Value);
        }
    }
}
