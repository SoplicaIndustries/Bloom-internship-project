using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbAPI.Data;
using DbAPI.Models;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ForeignController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{customerId}")]
        public ActionResult<int> GetBalance(Guid customerId)
        {
            IEnumerable<Transactions> customersTransactions =  _context.Transactions.Find(customerId);
            Transactions newestTransaction = customersTransactions.Max(tr => tr.Date);
            return Ok(newestTransaction.Balance_After);
        }


    }
}
