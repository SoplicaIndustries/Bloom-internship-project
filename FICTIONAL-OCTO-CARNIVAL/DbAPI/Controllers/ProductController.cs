using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CustomerController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Customers>> Get()
        {
            return context.Customers;
        }

        [HttpGet("{id}")]
        public ActionResult<Customers> Get(int id)
        {
            return context.Customers.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Customers customer)
        {

            context.Customers.Add(customer);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Customers goodItem)
        {
            var badItem = context.Customers.Find(goodItem.GUID);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Customers.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Customers.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

