using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public DiscountController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Discounts>> Get()
        {
            return context.Discounts;
        }

        [HttpGet("{id}")]
        public ActionResult<Discounts> Get(int id)
        {
            return context.Discounts.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Discounts discounts)
        {

            context.Discounts.Add(discounts);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Discounts goodItem)
        {
            var badItem = context.Discounts.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Discounts.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Discounts.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

