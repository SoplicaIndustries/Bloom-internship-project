using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ProductController(IConfiguration configuration, ApplicationDbContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Products>> Get()
        {
            return context.Products;
        }

        [HttpGet("{id}")]
        public ActionResult<Products> Get(int id)
        {
            return context.Products.Find(id);
        }

        [HttpPost]
        public ActionResult Post(Products customer)
        {

            context.Products.Add(customer);
            return Ok(context.SaveChanges());

        }



        [HttpPut]
        public ActionResult Put(Products goodItem)
        {
            var badItem = context.Products.Find(goodItem.Id);
            context.Entry(badItem).CurrentValues.SetValues(goodItem);
            return Ok(context.SaveChanges());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var itemToDelete = context.Products.Find(id);

            if (itemToDelete == null) return BadRequest("no worker was found");
            context.Products.Remove(itemToDelete);

            return Ok(context.SaveChanges());
        }




    }




}

