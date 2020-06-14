using AutoMapper;
using EnrollmentSystem.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Profiles
{
    public class StudentsProfile : Profile
    {
        public StudentsProfile()
        {

            CreateMap<Entities.Student, Models.StudentDto>()
               .ForMember(dest => dest.FullName,
               opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
               .ForMember(dest => dest.Age,
               opt => opt.MapFrom(src => src.Birthday.GetCurrentAge()));

            CreateMap<Models.StudentForCreationDto, Entities.Student>();
        }

    }
}

