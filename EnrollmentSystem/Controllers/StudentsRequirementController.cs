using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Controllers
{
    [ApiController]
    [Route("api/students/{studentId}/requirements")]
    public class StudentsRequirementController : ControllerBase
    {
        private readonly IEnrollmentSystemRepository _repository;
        private readonly IMapper _mapper;
        public StudentsRequirementController(IEnrollmentSystemRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet(Name = "GetRequirements")]
        public IActionResult GetStudentRequirement(Guid studentId)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }
            var studentRequirement = _repository.GetStudentRequirement(studentId);

            return Ok(_mapper.Map<StudentRequirementDto>(studentRequirement));

        }

        [HttpPost]
        public IActionResult CreateRequirement(Guid studentId, [FromBody] StudentRequirementForCreationDto studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var studentEntity = _mapper.Map<StudentRequirement>(studentModel);
            _repository.AddStudentRequirements(studentId, studentEntity);
            _repository.Save();

            var entityToReturn = _mapper.Map<StudentRequirementDto>(studentEntity);

            return CreatedAtRoute("GetRequirements", new { studentId = entityToReturn.StudentId }, entityToReturn);

        }

    }
}
