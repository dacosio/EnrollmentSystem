using AutoMapper;
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
    [Route("api/transactions")]
    public class TransactionsController : ControllerBase
    {
        private readonly IEnrollmentSystemRepository _repository;
        private readonly IMapper _mapper;

        public TransactionsController(IEnrollmentSystemRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            var entityToReturn = _repository.GetTransactions();

            return Ok(_mapper.Map<IEnumerable<TransactionDto>>(entityToReturn));
        }

        [HttpGet("{transactionId}", Name = "GetTransactionId")]
        public IActionResult GetTransaction(Guid transactionId)
        {

            if (!_repository.TransactionExists(transactionId))
            {
                return NotFound();
            }

            var entityToReturn = _repository.GetTransaction(transactionId);

            return Ok(_mapper.Map<TransactionDto>(entityToReturn));
        }

       


    }
}
