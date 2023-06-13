using AutoMapper;
using ToDo.WebApi.DTOs;

namespace ToDo.WebApi.MappingProfiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile() {
            CreateMap<Bizlite.Core.Entities.TblEmployee, EmployeeDto>();
            CreateMap<EmployeeCreateUpdateDto, Bizlite.Core.Entities.TblEmployee>();
        }
        
    }
}
