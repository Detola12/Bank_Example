using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SampleBank.Models;

namespace SampleBank.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers{ get; set; }
        public DbSet<Account> Accounts{ get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
    }
}