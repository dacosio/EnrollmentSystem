using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentSystem.Models
{
    public class TransactionForCreationDto
    {

        public string Payable { get; set; } //name of payable ex. Miscellaneous fee

        public decimal AmountPaid { get; set; }

        public decimal Balance { get; set; }

        public DateTime DateTimePaid { get; set; } = DateTime.Now;

    }
}
