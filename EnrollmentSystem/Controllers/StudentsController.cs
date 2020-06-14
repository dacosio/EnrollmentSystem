using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IEnrollmentSystemRepository _repository;
        private readonly IMapper _mapper;

        public StudentsController(IEnrollmentSystemRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetStudents()
        {

            var students = _repository.GetStudents();

            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));

        }

        [HttpGet("{studentId}",Name = "GetAuthor")]
        public IActionResult GetStudent(Guid studentId)
        {
            var student = _repository.GetStudent(studentId);

            if (student == null)
            {
                return BadRequest();
            }

            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody]Student studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var studentEntity = _mapper.Map<Student>(studentModel);

            _repository.AddStudent(studentEntity);
            _repository.Save();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);

            return CreatedAtRoute("GetAuthor", new { studentId = studentToReturn.Id }, studentEntity);

        }


    }
}
