using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleBank.Dto.Customer;
using SampleBank.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SampleBank.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository repo;
        // private readonly IAccountServic _service;
        // private readonly IAccountRepository accountRepository;
        public CustomerController(ICustomerRepository repository)
        {
            repo = repository;
            // _service = service;
            // this.accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult RegisterCustomer([FromBody] CreateCustomerDto customerDto){
            try{
                var customer = repo.RegisterCustomer(customerDto);
                return Ok(new{ Status = "Success", Message = "Customer Created Successfully", Data = customer});
            }
            catch(Exception){
                return BadRequest(new{ Status = "Failed", Message = "Duplicate Entry"});
            }
        }

        [HttpGet]
        public IActionResult GetAllCustomers(){
            var customer = repo.GetAllCustomers();
            return Ok(new{ Status = "Success", Message = customer});
        }

        [HttpGet("{id}")]
        public IActionResult GetCustomersById([FromRoute] Guid id){
            var customer = repo.GetCustomer(id);
            if(customer == null){
                return BadRequest(new{ Status = "Failed", Message = "Customer does not exist"});
            }
            return Ok(new{ Status = "Success", Message = customer});
        }

        // [HttpGet("CreateAccount/{customerId}")]
        // public IActionResult CreateAccount([FromRoute] Guid customerId){
        //     if(!repo.CheckCustomer(customerId)){
        //         return BadRequest(new{Status = "Failed", Message = "Customer does not exist"});
        //     }
        //     if(accountRepository.CheckAccount(customerId)){
        //         return BadRequest(new{Status = "Failed", Message = "Account already exist"});
        //     }
        //     var accountNo = _service.GenerateAccountNumber();
        //     var account = accountRepository.CreateAccount(accountNo, customerId);
           
        //     return Ok(new{ Status = "Success", Message = "Account Created Successfully", Data = account});
        // }

        [HttpPatch("upgrade/{customerId}")]
        public IActionResult UpgradeTier([FromRoute] Guid customerId){
            if(repo.UpgradeTier(customerId)){
                return Ok(new{ Status = "Success", Message = "Upgrade successfully"});
            }
            return BadRequest(new{ Status = "Failed", Message = "Could not upgrade tier"});

        }
    }
}