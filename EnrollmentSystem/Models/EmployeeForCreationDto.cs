using EnrollmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class EmployeeForCreationDto
    {
       
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public Guid TransactionId { get; set; }
        //public ICollection<TransactionForCreationDto> Transactions { get; set; } = new List<TransactionForCreationDto>();

    }
}
