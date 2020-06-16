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
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEnrollmentSystemRepository _repository;
        private readonly IMapper _mapper;
        public EmployeesController(IMapper mapper, IEnrollmentSystemRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetEmployee()
        {
            var employees = _repository.GetEmployees();
            return Ok( _mapper.Map<IEnumerable<EmployeeDto>>(employees));
        }

        [HttpGet("{employeeId}", Name = "GetEmployee")]
        public IActionResult GetEmployee(Guid employeeId)
        {
            if (!_repository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            var employee = _repository.GetEmployee(employeeId);

            return Ok(_mapper.Map<EmployeeDto>(employee));
        }

        [HttpGet("{employeeId}/transactions")]
        public IActionResult GetTransactionOfEmployee(Guid employeeId)
        {

            if (!_repository.EmployeeExists(employeeId))
            {
                return NotFound();
            }

            //var entityToReturn = _repository.GetTransactionsOfEmployee(employeeId);

            //return Ok(_mapper.Map<TransactionDto>(entityToReturn));
            return Ok();
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody] EmployeeForCreationDto employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var employeeEntity = _mapper.Map<Employee>(employee);
            _repository.AddEmployee(employeeEntity);
            _repository.Save();

            var entityToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return CreatedAtRoute("GetEmployee", new { employeeId = entityToReturn.Id }, entityToReturn);
        }
    }
}
