using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Data;
using SampleBank.Dto.Transaction;
using SampleBank.Interfaces;
using SampleBank.Models;

namespace SampleBank.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly BankContext _context;
        public TransactionRepository(BankContext context)
        {
            _context = context;
        }
        public TransactionDto Deposit(DepositDto depositDto)
        {
            var account = _context.Accounts.FirstOrDefault(x => x.Id == depositDto.AccountId);
            if (account == null){
                throw new Exception("Account Does Not Exist");
            }
            var customer =  _context.Customers.FirstOrDefault(y => y.Id == account.CustomerId);

            var transaction = new Transaction{
                AccountId = depositDto.AccountId,
                Amount = depositDto.amount,
                CustomerId = account.CustomerId,
                TransactionType = TransactionType.DEPOSIT
            };

            if(customer.Tier == 1){
                if(account.AccountBalance + depositDto.amount > 50000){
                    throw new Exception("Tier Balance Exceeded");
                }
                else{
                    account.AccountBalance += depositDto.amount;
                }
            }
            
            

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            var transactionDto = new TransactionDto{
                AccountId = account.Id,
                Amount = depositDto.amount,
                CustomerId = account.CustomerId,
                TransactionType = "Deposit",
            };

            return transactionDto;
        }

        public List<TransactionDto> GetAllTransactions()
        {
            throw new NotImplementedException();
        }

        public TransactionDto GetTransactionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public TransactionDto Withdraw(WithdrawDto withdrawDto)
        {
            throw new NotImplementedException();
        }
    }
}