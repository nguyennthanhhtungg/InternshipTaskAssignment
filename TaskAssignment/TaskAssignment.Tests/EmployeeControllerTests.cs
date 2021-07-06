using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskAssignment.Controllers;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.Services;
using TaskAssignment.ViewModels;
using Xunit;

namespace TaskAssignment.Tests
{
    public class EmployeeControllerTests
    {
        private readonly EmployeeController employeeController;
        private readonly Mock<IEmployeeService> employeeServiceMock = new Mock<IEmployeeService>();
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();

        public EmployeeControllerTests()
        {
            employeeController = new EmployeeController(employeeServiceMock.Object, mapperMock.Object);
        }


        [Fact]
        public async Task GetAll_ShouldReturnOkObjectResultWithEmployeeList_WhenEmployeeExists()
        {
            //Arrange
            var employeeListDTO = new List<Employee>(2)
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
                            Email = "tung-thanh.nguyen@capgemini.com",
                            MarriageStatus = "Single",
                            Nationality = "Vietnam",
                            IsActived = true,
                            //DeptId = null,
                            //Dept = null
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
                            Email = "nguyenthanhtung884318@capgemini.com",
                            MarriageStatus = "Single",
                            Nationality = "Vietnam",
                            IsActived = false,
                            //DeptId = null,
                            //Dept = null
                        }
            };

            employeeServiceMock.Setup(x => x.GetAll()).ReturnsAsync(employeeListDTO);

            //Act
            var result = await employeeController.GetAll();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(employeeListDTO, okObjectResult.Value);
        }

        [Fact]
        public async Task GetAll_ShouldReturnOkObjectResultWithNothing_WhenEmployeeEmpty()
        {
            //Arrange
            employeeServiceMock.Setup(x => x.GetAll()).ReturnsAsync(() => new List<Employee>(0));

            //Act
            var result = await employeeController.GetAll();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(new List<Employee>(0), okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkObjectResultWithNothing_WhenEmployeeDoseNotExist()
        {
            //Arrange
            employeeServiceMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync((Employee)null);

            //Act
            var result = await employeeController.GetById(It.IsAny<int>());

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((Employee)null, okObjectResult.Value);
        }

        [Fact]
        public async Task GetById_ShouldReturnOkObjectResultWithEmployee_WhenEmployeeExists()
        {
            //Arrange
            var employeeDTO = new Employee
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
                //DeptId = null,
                //Dept = null
            };
            employeeServiceMock.Setup(x => x.GetWithEmployeeDepartmentsById(employeeDTO.EmployeeId)).ReturnsAsync(employeeDTO);

            //Act
            var result = await employeeController.GetById(employeeDTO.EmployeeId);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(employeeDTO, okObjectResult.Value);
        }


        [Fact]
        public async Task Add_ShouldReturnBadRequestObjectResult_WhenEmployeeViewModelInvalid()
        {
            var employeeViewModel = new EmployeeViewModel
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
                //DeptId = null
            };

            //Arrange
            employeeController.ModelState.AddModelError("EmployeeNo", "EmployeeNo is required");

            //Act
            var result = await employeeController.Add(employeeViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Add_ShouldReturnOkObjectResultWithEmployee_WhenEmployeeViewModelValid()
        {
            var employeeDTO = new Employee
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
                //DeptId = null
            };

            var employeeViewModel = new EmployeeViewModel
            {
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
                //DeptId = null
            };

            //Arrange
            mapperMock.Setup(x => x.Map<Employee>(employeeViewModel)).Returns(employeeDTO);
            employeeServiceMock.Setup(x => x.Add(employeeDTO)).ReturnsAsync(employeeDTO);

            //Act
            var result = await employeeController.Add(employeeViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(employeeDTO, okObjectResult.Value);
        }


        [Fact]
        public async Task Update_ShouldReturnBadRequestObjectResult_WhenEmployeeViewModelInvalid()
        {
            var employeeViewModel = new EmployeeViewModel
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
                //DeptId = null
            };

            //Arrange
            employeeController.ModelState.AddModelError("EmployeeNo", "EmployeeNo is required");

            //Act
            var result = await employeeController.Update(employeeViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task Update_ShouldReturnOkObjectResultWithEmployee_WhenEmployeeViewModelValid()
        {
            var employeeDTO = new Employee
            {
                EmployeeId = 1,
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
                //DeptId = null
            };

            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeId = 1,
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
                //DeptId = null
            };

            //Arrange
            mapperMock.Setup(x => x.Map<Employee>(employeeViewModel)).Returns(employeeDTO);
            employeeServiceMock.Setup(x => x.Update(employeeDTO)).ReturnsAsync(employeeDTO);

            //Act
            var result = await employeeController.Update(employeeViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(employeeDTO, okObjectResult.Value);
        }
    }
}
