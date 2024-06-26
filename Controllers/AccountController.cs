using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleBank.Interfaces;

namespace SampleBank.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository repo;
        public AccountController(IAccountRepository repository)
        {
            repo = repository;
        }

        [HttpPost]
        public IActionResult CreateAccount([FromBody] Guid customerId){
            var account = repo.CreateAccount(customerId);
            return Ok(account);
        }
    }
}