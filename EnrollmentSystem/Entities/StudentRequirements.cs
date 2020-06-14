using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Entities
{
    public class StudentRequirement
    {
        [Key, ForeignKey("Student")]
        public Guid StudentId { get; set; }

        [Required]
        public bool NSO { get; set; }
        public bool Baptismal { get; set; }

        [Required]
        public string EntranceExamResult { get; set; }

        [Required]
        [MaxLength(50)]
        public bool CertificateOfTransfer { get; set; }

        public Student Student { get; set; }

    }
}
