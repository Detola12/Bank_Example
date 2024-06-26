
using System.ComponentModel.DataAnnotations;

namespace SampleBank.Models
{
    public enum TransactionType
    {
        [Display(Name = "Withdraw")]
        WITHDRAW,
        [Display(Name = "Deposit")]
        DEPOSIT,
    }
}