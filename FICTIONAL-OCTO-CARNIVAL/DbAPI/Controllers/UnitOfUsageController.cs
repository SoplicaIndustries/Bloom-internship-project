using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitOfUsageController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public UnitOfUsageController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<UnitsOfUsage>> Get()
        {
            return context.UnitsOfUsage;
        }

        [HttpGet("{id}")]
        public ActionResult<UnitsOfUsage> Get(int id)
        {
            return context.UnitsOfUsage.Find(id);
        }

        [HttpPost]
        public ActionResult Post(UnitsOfUsage UnitsOfUsage)
        {

            context.UnitsOfUsage.Add(UnitsOfUsage);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(UnitsOfUsage goodItem)
        {
            var badItem = context.UnitsOfUsage.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.UnitsOfUsage.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.UnitsOfUsage.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

