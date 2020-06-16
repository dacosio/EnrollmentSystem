using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class StudentDetailForCreationDto
    {
        public string FatherName { get; set; }
        public string FatherOccupation { get; set; }
        public string MotherName { get; set; }
        public string MotherOccupation { get; set; }
        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        public string ParentAddress { get; set; }
        public string ParentNumber { get; set; }
    }
}
