using DbAPI.Data;
using DbAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<decimal> GetBalance(Guid customerId)
        {
            return Ok(Balance(_context, customerId));
        }

        [HttpGet("{customerId}, {productId}")]
        public ActionResult<bool> CheckAbilityToBuy(Guid customerId, Guid productId)
        {//!!!!!W przypadku braku zadanego customer_guid w bazie BillingService, ma zostać dodany.
            IEnumerable<Transactions> customersTransactions = _context.Transactions.Where(tr => tr.Customer_Id == customerId).ToList().AsEnumerable();//nie pytac po co 2 razy konwersja, inaczej wybucha

#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            Products product = _context.Products.Find(productId);
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
#pragma warning disable CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
            if (Balance(_context, customerId) >= product.Price) return Ok(true);
#pragma warning restore CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
            return Ok(false);

        }

        [HttpPost("{customerId}")]
        public ActionResult RegisterTransaction(Guid customerId, Guid productId)
        {   //zapytaj sie szefa o customer name
            if (_context.Customers.Find(customerId) == null) _context.Customers.Add(new Customers { Id = customerId, Name = "Anonymous" });
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            Products product = _context.Products.Find(productId);
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            var balance = Balance(_context, customerId);
            if (product == null) return NotFound("Product not found");
            if (balance < product.Price) return BadRequest("Insufficient resources");
            Transactions transaction = new Transactions { Id = new Guid(), Description = product.Name, Price = product.Price, Balance_After = Decimal.Subtract(Balance(_context, customerId), product.Price), Date = DateTime.Now, Reference_Number = new Guid(), Currency_Id = product.Currency_Id, Customer_Id = customerId };
            _context.Transactions.Add(transaction);
            return Ok(_context.SaveChanges());

        }

        private static decimal Balance(ApplicationDbContext _context, Guid customerId)
        {
            if (_context.Customers.Find(customerId) == null)
            {
                _context.Customers.Add(new Customers { Id = customerId, Name = "Anonymous" });
                return 0;
            }

            IEnumerable<Transactions> customersTransactions = _context.Transactions.Where(tr => tr.Customer_Id == customerId).ToList().AsEnumerable();
            if (customersTransactions.Count() <= 0) return 0;
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
            Transactions newestTransaction = customersTransactions.FirstOrDefault(tr => tr.Date == customersTransactions.Max(tr => tr.Date));
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
#pragma warning disable CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
            return newestTransaction.Balance_After;
#pragma warning restore CS8602 // Wyłuskanie odwołania, które może mieć wartość null.
        }

    }
}
