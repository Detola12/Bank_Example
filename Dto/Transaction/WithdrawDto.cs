using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBank.Dto.Transaction
{
    public class WithdrawDto
    {
        public Guid AccountId {get; set;}
        public decimal amount {get; set;}
    }
}