using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Dto.Account;

namespace SampleBank.Interfaces
{
    public interface IAccountRepository
    {
        public List<AccountDto> GetAllAccounts();
        public AccountDto GetAccountById(Guid id);
        public AccountDto CreateAccount(Guid customerId);
        public string GenerateAccountNumber();
    }
}