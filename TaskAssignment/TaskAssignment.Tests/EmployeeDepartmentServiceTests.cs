using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TaskAssignment.Models;
using TaskAssignment.Repositories;
using TaskAssignment.Services;
using Xunit;

namespace TaskAssignment.Tests
{
    public class EmployeeDepartmentServiceTests
    {
        private readonly EmployeeDepartmentService employeeDepartmentService;
        private readonly Mock<IEmployeeDepartmentRepository> employeeDepartmentRepositoryMock = new Mock<IEmployeeDepartmentRepository>();

        public EmployeeDepartmentServiceTests()
        {
            employeeDepartmentService = new EmployeeDepartmentService(employeeDepartmentRepositoryMock.Object);
        }

        [Fact]
        public async Task Add_ShouldReturnAddedEmployeeDepartment_WhenEmployeeDepartmentValid()
        {
            //Arrange
            EmployeeDepartment previousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment updatedPriviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-2),
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(previousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Update(updatedPriviousEmployeeDepartmentDTO));
            employeeDepartmentRepositoryMock.Setup(x => x.Add(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Add(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Equal(nextEmployeeDepartmentDTO, employeeDepartment);
        }


        [Fact]
        public async Task Add_ShouldReturnNothing_WhenNextStartDateLowerOrEqualPreviousStartDate()
        {
            //Arrange
            EmployeeDepartment priviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(priviousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Add(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Add(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Null(employeeDepartment);
        }



        [Fact]
        public async Task Add_ShouldReturnNothing_WhenNextDeptIDEqualPreviousDeptID()
        {
            //Arrange
            EmployeeDepartment priviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(priviousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Add(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Add(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Null(employeeDepartment);
        }



        [Fact]
        public async Task Update_ShouldReturnUpdatedEmployeeDepartment_WhenEmployeeDepartmentValid()
        {
            //Arrange
            EmployeeDepartment previousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment updatedPriviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-3),
                EndDate = DateTime.Now.AddDays(-2),
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestCompletedEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(previousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Update(updatedPriviousEmployeeDepartmentDTO));
            employeeDepartmentRepositoryMock.Setup(x => x.Update(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Update(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Equal(nextEmployeeDepartmentDTO, employeeDepartment);
        }


        [Fact]
        public async Task Update_ShouldReturnNothing_WhenNextStartDateLowerOrEqualPreviousStartDate()
        {
            //Arrange
            EmployeeDepartment priviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 2,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestCompletedEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(priviousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Update(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Update(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Null(employeeDepartment);
        }



        [Fact]
        public async Task Update_ShouldReturnNothing_WhenNextDeptIDLowerOrEqualPreviousDeptID()
        {
            //Arrange
            EmployeeDepartment priviousEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 1,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = null,
                Description = "abc"
            };

            EmployeeDepartment nextEmployeeDepartmentDTO = new EmployeeDepartment
            {
                ID = 2,
                EmployeeID = 1,
                DeptID = 1,
                StartDate = DateTime.Now,
                EndDate = null,
                Description = "abc"
            };

            employeeDepartmentRepositoryMock.Setup(x => x.GetLastestCompletedEmployeeDepartmentByEmployeeId(nextEmployeeDepartmentDTO.EmployeeID)).ReturnsAsync(priviousEmployeeDepartmentDTO);
            employeeDepartmentRepositoryMock.Setup(x => x.Update(nextEmployeeDepartmentDTO));


            //Act
            var employeeDepartment = await employeeDepartmentService.Update(nextEmployeeDepartmentDTO);

            //Assert
            Assert.Null(employeeDepartment);
        }
    }
}
