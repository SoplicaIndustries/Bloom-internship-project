using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public InvoicesController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Invoices>> Get()
        {
            return context.Invoices;
        }

        [HttpGet("{id}")]
        public ActionResult<Invoices> Get(int id)
        {
            return context.Invoices.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Invoices Invoices)
        {

            context.Invoices.Add(Invoices);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Invoices goodItem)
        {
            var badItem = context.Invoices.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Invoices.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Invoices.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

