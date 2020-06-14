using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class StudentForCreationDto
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }

        public DateTimeOffset Birthday { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public string BirthPlace { get; set; }

        public string Nationality { get; set; }

        public string StudentPhoneNumber { get; set; }

    }
}
