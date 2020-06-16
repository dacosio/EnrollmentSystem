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
            CreateMap<Models.StudentForUpdateDto, Entities.Student>();

            CreateMap<Entities.StudentDetail, Models.StudentDetailDto>();
            CreateMap<Models.StudentDetailForCreationDto, Entities.StudentDetail>();
            CreateMap<Models.StudentDetailForUpdateDto, Entities.StudentDetail>();

            CreateMap<Entities.StudentRequirement, Models.StudentRequirementDto>();
            CreateMap<Models.StudentRequirementForCreationDto, Entities.StudentRequirement>();
            CreateMap<Models.StudentRequirementForUpdateDto, Entities.StudentRequirement>();

            CreateMap<Entities.SchoolYear, Models.SchoolYearDto>().ReverseMap();
            CreateMap<Models.ShoolYearForUpdateDto, Entities.SchoolYear>();
        }

    }
}

