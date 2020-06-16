using EnrollmentSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class StudentDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string Gender { get; set; }
        public int Age { get; set; }

        //public ICollection<TransactionDto> Transactions { get; set; } 
    }
}
