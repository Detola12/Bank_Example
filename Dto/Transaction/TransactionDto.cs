using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBank.Dto.Transaction
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string TransactionType { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public Guid AccountId { get; set; }
    }
}