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
            InvoiceGenerator.GenerateInvoice(customersTransactions.ToList(), "sdadsas");
            Products product = _context.Products.Find(productId);
            if (Balance(_context, customerId) >= product.Price) return Ok(true);
            return Ok(false);

        }

        [HttpPost("{customerId}")]
        public ActionResult RegisterTransaction(Guid customerId, Guid productId)
        {   //zapytaj sie szefa o customer name
            if (_context.Customers.Find(customerId) == null) _context.Customers.Add(new Customers { Id = customerId, Name = "Anonymous" });
            Products product = _context.Products.Find(productId);
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
            Transactions newestTransaction = customersTransactions.FirstOrDefault(tr => tr.Date == customersTransactions.Max(tr => tr.Date));
            return newestTransaction.Balance_After;
        }

    }
}
