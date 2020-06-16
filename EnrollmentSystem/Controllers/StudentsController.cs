using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{studentId}",Name = "GetStudent")]
        public IActionResult GetStudent(Guid studentId)
        {
            var student = _repository.GetStudent(studentId);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public IActionResult CreateStudent([FromBody]StudentForCreationDto studentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var studentEntity = _mapper.Map<Student>(studentModel);

            _repository.AddStudent(studentEntity);
            _repository.Save();

            var studentToReturn = _mapper.Map<StudentDto>(studentEntity);

            return CreatedAtRoute("GetStudent", new { studentId = studentToReturn.Id }, studentToReturn);

        }

        [HttpPut("{studentId}")]
        public IActionResult UpdateStudent(Guid studentId, StudentForUpdateDto student)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentToUpdate = _repository.GetStudent(studentId);

            if (studentToUpdate == null)
            {
                var studentToAdd = _mapper.Map<Student>(student);
                studentToAdd.Id = studentId;
                _repository.AddStudent(studentToAdd);
                _repository.Save();

                var entityToReturn = _mapper.Map<StudentDto>(studentToAdd);

                return CreatedAtRoute("GetStudent", new { studentId = entityToReturn.Id}, entityToReturn);
            }

            // map the entity to a StudentUpdateDto
            // apply the updated field values to that dto
            // map the CourseForUpdateDto back to an entity
            _mapper.Map(student, studentToUpdate);
            _repository.UpdateStudent(studentToUpdate);
            _repository.Save();
            return NoContent();
        }

        [HttpPatch("{studentId}")]
        public ActionResult PartiallyUpdateStudent(Guid studentId, JsonPatchDocument<StudentForUpdateDto> patchDocument)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }
            var studentToUpdate = _repository.GetStudent(studentId);

            if (studentToUpdate == null)
            {
                var studentDto = new StudentForUpdateDto();
                patchDocument.ApplyTo(studentDto, ModelState);

                if (!TryValidateModel(studentDto))
                {
                    return ValidationProblem(ModelState);
                }

                var studentToAdd = _mapper.Map<Student>(studentDto);
                studentToAdd.Id = studentId;

                _repository.AddStudent(studentToAdd);
                _repository.Save();

                var entityToReturn = _mapper.Map<StudentDto>(studentToAdd);

                return CreatedAtRoute("GetStudent", new { studentId= entityToReturn.Id }, entityToReturn);
            }

            var studentToPatch = _mapper.Map<StudentForUpdateDto>(studentToUpdate);
            // add validation
            patchDocument.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentToPatch, studentToUpdate);
            _repository.UpdateStudent(studentToUpdate);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete("{studentId}")]
        public IActionResult DeleteStudent(Guid studentId)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentToDelete = _repository.GetStudent(studentId);
            _repository.DeleteStudent(studentToDelete);
            _repository.Save();

            return NoContent();

        }


    }
}
