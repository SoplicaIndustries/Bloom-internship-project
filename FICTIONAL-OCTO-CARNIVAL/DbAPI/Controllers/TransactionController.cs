using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public TransactionController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Transactions>> Get()
        {
            return context.Transactions;
        }

        [HttpGet("{id}")]
        public ActionResult<Transactions> Get(int id)
        {
            return context.Transactions.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Transactions Transactions)
        {

            context.Transactions.Add(Transactions);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Transactions goodItem)
        {
            var badItem = context.Transactions.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Transactions.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Transactions.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

