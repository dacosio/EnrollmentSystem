using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Entities
{
    public class SchoolYear
    {
        [Key, ForeignKey("Student")]
        public Guid StudentId { get; set; }

        [Required]
        [MaxLength(11)]
        public int Year { get; set; }

        public Student Student { get; set; }



    }
}
