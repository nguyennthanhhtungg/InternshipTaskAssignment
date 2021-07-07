using AutoMapper;
using TaskAssignment.Models;
using TaskAssignment.ViewModels;

namespace TaskAssignment.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeViewModel, Employee>().ReverseMap();
            CreateMap<DepartmentViewModel, Department>().ReverseMap();
            CreateMap<EmployeeDepartmentViewModel, EmployeeDepartment>().ReverseMap();
        }
    }
}
