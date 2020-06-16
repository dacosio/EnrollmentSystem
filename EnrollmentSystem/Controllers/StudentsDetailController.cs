using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EnrollmentSystem.Controllers
{
    [Route("api/students/{studentId}/details")]
    [ApiController]
    public class StudentsDetailController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IEnrollmentSystemRepository _repository;
        public StudentsDetailController(IMapper mapper, IEnrollmentSystemRepository repository)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet(Name = "GetDetail")]
        public IActionResult GetStudentDetail(Guid studentId)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }
            var studentDetail = _repository.GetStudentDetail(studentId);

            return Ok(_mapper.Map<StudentDetailDto>(studentDetail));
        }

        [HttpPost]
        public IActionResult CreateStudentDetail(Guid studentId, StudentDetailForCreationDto studentDetail)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentDetailEntity = _mapper.Map<StudentDetail>(studentDetail);
            _repository.AddStudentDetail(studentId, studentDetailEntity);
            _repository.Save();

            var entityToReturn = _mapper.Map<StudentDetailDto>(studentDetailEntity);

            return CreatedAtRoute("GetDetail", new { studentId = entityToReturn.StudentId }, entityToReturn);
        }

        [HttpPut]

    }
}
