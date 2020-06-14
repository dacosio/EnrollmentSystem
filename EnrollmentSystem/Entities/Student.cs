using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Entities
{
    public class Student
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTimeOffset Birthday { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        [Required]
        [MaxLength(200)]
        public string BirthPlace { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nationality { get; set; }
      
        [Required]
        [MaxLength(50)]
        public string StudentPhoneNumber { get; set; }
        public virtual StudentDetail StudentDetail { get; set; }
        public virtual StudentRequirement StudentRequirement { get; set; }
        public virtual SchoolYear SchoolYear { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();



    }
}
