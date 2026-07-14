using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ropositories.Models;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly NorthwindContext _context;
    public CustomersController(NorthwindContext context)
    {
        _context = context;
    }

    // GET: api/Customer
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ropositories.Models.Customer>>> GetCustomer()
    {
        return await _context.Customers.Take(10).ToListAsync();
    }

    // GET: api/Customer/5
    [HttpGet("{customerid}")]
    public async Task<ActionResult<Ropositories.Models.Customer>> GetCustomer(string customerid)
    {
        var customer = await _context.Customers.FindAsync(customerid);

        if (customer == null)
        {
            return NotFound();
        }

        return customer;
    }

    // PUT: api/Customer/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{customerid}")]
    public async Task<IActionResult> PutCustomer(string? customerid, Ropositories.Models.Customer customer)
    {
        if (customerid != customer.CustomerId)
        {
            return BadRequest();
        }

        _context.Entry(customer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CustomerExists(customerid))
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
    public async Task<ActionResult<Ropositories.Models.Customer>> PostCustomer(Ropositories.Models.Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCustomer", new { customerid = customer.CustomerId }, customer);
    }

    // DELETE: api/Customer/5
    [HttpDelete("{customerid}")]
    public async Task<IActionResult> DeleteCustomer(string? customerid)
    {
        var customer = await _context.Customers.FindAsync(customerid);
        if (customer == null)
        {
            return NotFound();
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CustomerExists(string? customerid)
    {
        return _context.Customers.Any(e => e.CustomerId == customerid);
    }
}
