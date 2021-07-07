using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.Services;
using Xunit;

namespace TaskAssignment.Tests
{
    public class EmployeeServiceTests
    {
        private readonly EmployeeService employeeService;
        private readonly Mock<IEmployeeRepository> employeeRepositoryMock = new Mock<IEmployeeRepository>();

        public EmployeeServiceTests()
        {
            employeeService = new EmployeeService(employeeRepositoryMock.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnEmployee_WhenEmployeeExists()
        {
            //Arrange
            Employee employeeDTO = new Employee
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
            };

            employeeRepositoryMock.Setup(x => x.GetById(1)).ReturnsAsync(employeeDTO);


            //Act
            var employee = await employeeService.GetById(employeeDTO.EmployeeId);

            //Assert
            Assert.Equal(employeeDTO, employee);
        }


        [Fact]
        public async Task GetById_ShouldReturnNothing_WhenEmployeeDoesNotExist()
        {
            //Arrange
            employeeRepositoryMock.Setup(x => x.GetById(It.IsAny<int>())).ReturnsAsync(() => null);


            //Act
            var employee = await employeeService.GetById(It.IsAny<int>());

            //Assert
            Assert.Null(employee);
        }


        [Fact]
        public async Task GetAll_ShouldReturnEmployeeList_WhenEmployeeListExists()
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

            employeeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(employeeListDTO);


            //Act
            var employees = await employeeService.GetAll();

            //Assert
            Assert.Equal(employeeListDTO, employees);
        }

        [Fact]
        public async Task GetAll_ShouldReturnNothing_WhenEmployeeListEmpty()
        {
            //Arrange
            employeeRepositoryMock.Setup(x => x.GetAll()).ReturnsAsync(() => new Employee[0]);

            //Act
            var employees = await employeeService.GetAll();

            //Assert
            Assert.Equal(new Employee[0], employees);
        }
    }
}
