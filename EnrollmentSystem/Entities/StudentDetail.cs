using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Entities
{
    public class StudentDetail
    {
        [Key, ForeignKey("Student")]
        public Guid StudentId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FatherName { get; set; }
        [Required]
        [MaxLength(50)]
        public string FatherOccupation { get; set; }
        [Required]
        [MaxLength(50)]
        public string MotherName { get; set; }
        [Required]
        [MaxLength(50)]
        public string MotherOccupation { get; set; }

        public string GuardianName { get; set; }
        public string GuardianOccupation { get; set; }
        [Required]
        [MaxLength(50)]
        public string ParentAddress { get; set; }
        [Required]
        [MaxLength(50)]
        public string ParentNumber { get; set; }

        public Student Student { get; set; }




    }
}
