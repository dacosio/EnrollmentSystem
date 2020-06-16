using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class StudentRequirementForCreationDto
    {

        public bool NSO { get; set; }
        public bool Baptismal { get; set; }
        public string EntranceExamResult { get; set; }
        public bool CertificateOfTransfer { get; set; }

    }
}
