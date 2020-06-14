using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Entities
{
    public class Transaction
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Payable { get; set; } //name of payable ex. Miscellaneous fee

        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountPaid { get; set; }


        [Required]
        [Column(TypeName = "decimal(18,4)")]

        public decimal Balance { get; set; }

        [Required]

        public DateTime DateTimePaid { get; set; }


        [ForeignKey("StudentId")]
        public Student Students { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employees { get; set; }

        public Guid StudentId { get; set; }
        public Guid EmployeeId { get; set; }







    }
}
