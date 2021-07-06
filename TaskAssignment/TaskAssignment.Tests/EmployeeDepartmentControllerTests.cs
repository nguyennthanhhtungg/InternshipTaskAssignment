using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment.Controllers;
using TaskAssignment.Models;
using TaskAssignment.Services;
using TaskAssignment.ViewModels;
using Xunit;

namespace TaskAssignment.Tests
{
    public class EmployeeDepartmentControllerTests
    {
        private readonly EmployeeDepartmentController employeeDepartmentController;
        private readonly Mock<IEmployeeDepartmentService> employeeDepartmentServiceMock = new Mock<IEmployeeDepartmentService>();
        private readonly Mock<IMapper> mapperMock = new Mock<IMapper>();

        public EmployeeDepartmentControllerTests()
        {
            employeeDepartmentController = new EmployeeDepartmentController(employeeDepartmentServiceMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task Add_ShouldReturnBadRequestObjectResult_WhenEmployeeDepartmentViewModelInvalid()
        {
            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                //EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            employeeDepartmentController.ModelState.AddModelError("EmployeeID", "EmployeeID is required");

            //Act
            var result = await employeeDepartmentController.Add(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Add_ShouldReturnBadRequestObjectResult_WhenNextStartDateLowerOrEqualPreviousStartDate()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Add(nextEmployeeDepartmentDTO)).ReturnsAsync(() => null);

            //Act
            var result = await employeeDepartmentController.Add(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Add_ShouldReturnBadRequestObjectResult_WhenNextDeptIDEqualPreviousDeptID()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Add(nextEmployeeDepartmentDTO)).ReturnsAsync(() => null);

            //Act
            var result = await employeeDepartmentController.Add(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task Add_ShouldReturnOkObjectResultWithEmployeeDepartment_WhenEmployeeViewModelValid()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Add(nextEmployeeDepartmentDTO)).ReturnsAsync(nextEmployeeDepartmentDTO);

            //Act
            var result = await employeeDepartmentController.Add(nextEmployeeDepartmentViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(nextEmployeeDepartmentDTO, okObjectResult.Value);
        }


        [Fact]
        public async Task Update_ShouldReturnBadRequestObjectResult_WhenEmployeeDepartmentViewModelInvalid()
        {
            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                //EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            employeeDepartmentController.ModelState.AddModelError("EmployeeID", "EmployeeID is required");

            //Act
            var result = await employeeDepartmentController.Update(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequestObjectResult_WhenNextStartDateLowerOrEqualPreviousStartDate()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Update(nextEmployeeDepartmentDTO)).ReturnsAsync(() => null);

            //Act
            var result = await employeeDepartmentController.Update(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Update_ShouldReturnBadRequestObjectResult_WhenNextDeptIDEqualPreviousDeptID()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Update(nextEmployeeDepartmentDTO)).ReturnsAsync(() => null);

            //Act
            var result = await employeeDepartmentController.Update(nextEmployeeDepartmentViewModel);

            //Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }


        [Fact]
        public async Task Update_ShouldReturnOkObjectResultWithEmployeeDepartment_WhenEmployeeViewModelValid()
        {
            var nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now,
                Description = "abc"
            };

            var nextEmployeeDepartmentViewModel = new EmployeeDepartmentViewModel
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                Description = "abc"
            };

            //Arrange
            mapperMock.Setup(x => x.Map<EmployeeDepartment>(nextEmployeeDepartmentViewModel)).Returns(nextEmployeeDepartmentDTO);
            employeeDepartmentServiceMock.Setup(x => x.Update(nextEmployeeDepartmentDTO)).ReturnsAsync(nextEmployeeDepartmentDTO);

            //Act
            var result = await employeeDepartmentController.Update(nextEmployeeDepartmentViewModel);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(nextEmployeeDepartmentDTO, okObjectResult.Value);
        }
    }
}
