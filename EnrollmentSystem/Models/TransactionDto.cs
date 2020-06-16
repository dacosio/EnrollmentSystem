using System;
using System.Globalization;

namespace EnrollmentSystem.Models
{
    public class TransactionDto
    {

        public Guid Id { get; set; }
        
        public string Payable { get; set; } //name of payable ex. Miscellaneous fee
        public decimal AmountPaid { get; set; }

        public decimal Balance { get; set; }

        public DateTime DateTimePaid { get; set; }

        public Guid StudentId { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
