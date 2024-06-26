using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleBank.Dto.Account
{
    public class AccountDto
    {
        public Guid CustomerId {get; set;}
        public string AccountNo {get;set;} = string.Empty;
        public decimal AccountBalance {get; set;} = 0;
        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}