using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Profiles
{
    public class EmployeesProfile : Profile
    {
        public EmployeesProfile()
        {
            CreateMap<Entities.Employee, Models.EmployeeDto>()
               .ForMember(dest => dest.FullName,
               opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));


            CreateMap<Models.EmployeeForCreationDto, Entities.Employee>();
        }
        

    }
}
