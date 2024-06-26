using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleBank.Dto.Transaction;
using SampleBank.Interfaces;

namespace SampleBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionRepository repo;
        public TransactionController(ITransactionRepository repository)
        {
            repo = repository;
        }

        [HttpPost]
        [Route("Deposit")]
        public IActionResult Deposit([FromBody] DepositDto depositDto){
            try{
                var transaction = repo.Deposit(depositDto);
                if(transaction == null){
                    return BadRequest(new{Status = "Failed", Message = "Something Went Wrong"});
                }

                return Ok(new{Status = "Success", Data = transaction});
            }
            catch(Exception ex){
                return BadRequest(new{Status = "Failed", Message = ex.Message});
            }
        }
    }
}