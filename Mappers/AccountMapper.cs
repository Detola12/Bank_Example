using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Dto.Account;
using SampleBank.Models;

namespace SampleBank.Mappers
{
    public static class AccountMapper
    {
        public static AccountDto ToAccountDto (this Account account){
            return new AccountDto {
                CustomerId = account.CustomerId,
                AccountNo = account.AccountNo,
                AccountBalance = account.AccountBalance,
                CreatedAt = account.CreatedAt,
            };
        }
    }
}