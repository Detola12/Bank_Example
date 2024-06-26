using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Data;
using SampleBank.Dto.Account;
using SampleBank.Interfaces;
using SampleBank.Mappers;
using SampleBank.Models;

namespace SampleBank.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;
        public AccountRepository(BankContext context)
        {
            _context = context;
        }
        public AccountDto CreateAccount(Guid customerId)
        {
            var account = new Account{
                CustomerId = customerId,
                AccountNo = GenerateAccountNumber()
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return account.ToAccountDto();
        }

        // public AccountDto CreateAccount(Guid customerId)
        // {
        //     var account = new Account{
        //         CustomerId = customerId,
        //         AccountNo = GenerateAccountNumber()
        //     };

        //     _context.Accounts.Add(account);
        //     _context.SaveChanges();

        //     var accountDto = new AccountDto{
        //         CustomerId = account.CustomerId,
        //         AccountNo = account.AccountNo,
        //         AccountBalance = account.AccountBalance,
        //         CreatedAt = account.CreatedAt,
        //     };

        //     return accountDto;
        // }

        public string GenerateAccountNumber()
        {
            Random random = new Random();
            string letters = "123456789";
            int length = 8; // 78129276
            string accountNo = "";

            for (int i = 0; i < length; i++){
                accountNo += letters[random.Next(letters.Length)];
            }

            return accountNo;
        }

        public AccountDto GetAccountById(Guid id)
        {
            var accounts = _context.Accounts.FirstOrDefault(x => x.Id == id);
            if(accounts == null){
                return null;
            }
            return accounts.ToAccountDto();
        }

        public List<AccountDto> GetAllAccounts()
        {
            var accounts = _context.Accounts.Select(x => x.ToAccountDto()).ToList();
            return accounts;
        }
    }
}