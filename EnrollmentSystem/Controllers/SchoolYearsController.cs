using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("api/students/{studentId}/schoolyear")]
    public class SchoolYearsController : ControllerBase
    {
        private readonly IEnrollmentSystemRepository _repository;
        private readonly IMapper _mapper;
        public SchoolYearsController(IMapper mapper, IEnrollmentSystemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetSchoolYear")]
        public IActionResult GetSchoolYear(Guid studentId)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var entityModel = _repository.GetStudentSchoolYear(studentId);

            return Ok(_mapper.Map<SchoolYearDto>(entityModel));

        }

        [HttpPost]
        public IActionResult CreateSchoolYear(Guid studentId, [FromBody] SchoolYearDto schoolYear)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }


            var entityModel = _mapper.Map<SchoolYear>(schoolYear);
            _repository.AddStudentSchoolYear(studentId, entityModel);
            _repository.Save();

            var entityToReturn = _mapper.Map<SchoolYearDto>(entityModel);

            return CreatedAtRoute("GetSchoolYear", new { studentId = entityToReturn.StudentId }, entityToReturn);
        }


    }
}
