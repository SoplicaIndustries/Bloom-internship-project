using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CurrencyController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Currency>> Get()
        {
            return context.Currency;
        }

        [HttpGet("{id}")]
        public ActionResult<Currency> Get(int id)
        {
            return context.Currency.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Currency currency)
        {

            context.Currency.Add(currency);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Currency goodItem)
        {
            var badItem = context.Currency.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Currency.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Currency.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

