using AutoMapper;
using EnrollmentSystem.Entities;
using EnrollmentSystem.Models;
using EnrollmentSystem.Services;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpPut("studentId")]
        public IActionResult UpdateStudentDetail(Guid studentId, StudentDetailForUpdateDto studentDetail)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentDetailToUpdate = _repository.GetStudentDetail(studentId);

            if (studentDetailToUpdate == null)
            {

                var studentDetailToAdd = _mapper.Map<StudentDetail>(studentDetail);
                studentDetailToAdd.StudentId = studentId;
                _repository.AddStudentDetail(studentId, studentDetailToAdd);
                _repository.Save();

                var entityToReturn = _mapper.Map<StudentDetailDto>(studentDetailToAdd);

                return CreatedAtRoute("GetDetail", new { studentId = entityToReturn.StudentId }, entityToReturn);
            }

            _mapper.Map(studentDetail, studentDetailToUpdate);
            _repository.UpdateStudentDetail(studentId, studentDetailToUpdate);
            _repository.Save();
            return NoContent();
        }

        [HttpPatch("{studentId}")]
        public IActionResult PartiallyUpdateStudentDetail(Guid studentId, JsonPatchDocument<StudentDetailForUpdateDto> patchDocument)
        {

            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }
            var studentDetailToUpdate = _repository.GetStudentDetail(studentId);

            if (studentDetailToUpdate == null)
            {
                var studentDetailDto = new StudentDetailForUpdateDto();
                patchDocument.ApplyTo(studentDetailDto, ModelState);

                if (!TryValidateModel(studentDetailDto))
                {
                    return ValidationProblem(ModelState);
                }

                var studentDetailToAdd = _mapper.Map<StudentDetail>(studentDetailDto);
                studentDetailToAdd.StudentId = studentId;

                _repository.AddStudentDetail(studentId, studentDetailToAdd);
                _repository.Save();

                var entityToReturn = _mapper.Map<StudentDto>(studentDetailToAdd);

                return CreatedAtRoute("GetDetail", new { studentId = entityToReturn.Id }, entityToReturn);
            }

            var studentDetailToPatch = _mapper.Map<StudentDetailForUpdateDto>(studentDetailToUpdate);
            // add validation
            patchDocument.ApplyTo(studentDetailToPatch, ModelState);

            if (!TryValidateModel(studentDetailToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(studentDetailToPatch, studentDetailToUpdate);
            _repository.UpdateStudentDetail(studentId, studentDetailToUpdate);
            _repository.Save();
            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteStudentDetail(Guid studentId)
        {
            if (!_repository.StudentExists(studentId))
            {
                return NotFound();
            }

            var studentDetailToDelete = _repository.GetStudentDetail(studentId);

            _repository.DeleteStudentDetail(studentId, studentDetailToDelete);
            _repository.Save();

            return NoContent();
        }

    }
}
