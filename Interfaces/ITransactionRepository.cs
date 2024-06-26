using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Dto.Transaction;

namespace SampleBank.Interfaces
{
    public interface ITransactionRepository
    {
        public List<TransactionDto> GetAllTransactions();
        public TransactionDto GetTransactionById(Guid id);
        public TransactionDto Withdraw(WithdrawDto withdrawDto);
        public TransactionDto Deposit(DepositDto depositDto); 
    }
}