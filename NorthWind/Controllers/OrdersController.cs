using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ropositories.Models;

namespace NorthWind.Controllers
{
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public OrdersController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ropositories.Models.Order>>> GetOrder()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Order/5
        [HttpGet("{orderid}")]
        public async Task<ActionResult<Ropositories.Models.Order>> GetOrder(string orderid)
        {
            var order = await _context.Orders.FindAsync(orderid);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Order/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{orderid}")]
        public async Task<IActionResult> PutOrder(int orderid, Ropositories.Models.Order order)
        {
            if (orderid != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(orderid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customer
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ropositories.Models.Order>> PostOrder(Ropositories.Models.Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { orderid = order.OrderId }, order   );
        }

        // DELETE: api/Order/5
        [HttpDelete("{orderid}")]
        public async Task<IActionResult> DeleteOrder(string? orderid)
        {
            var order = await _context.Orders.FindAsync(orderid);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int? orderid)
        {
            return _context.Orders.Any(o => o.OrderId == orderid);
        }
    }
}
