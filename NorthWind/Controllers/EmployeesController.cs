using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ropositories.Models;

namespace NorthWind.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly NorthwindContext _context;
        public EmployeesController(NorthwindContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ropositories.Models.Employee>>> GetEmployee()
        {
            return await _context.Employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{employeeid}")]
        public async Task<ActionResult<Ropositories.Models.Employee>> GetEmployee(string employeeid)
        {
            var employee = await _context.Employees.FindAsync(employeeid);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{employeeid}")]
        public async Task<IActionResult> PutEmployee(int? employeeid, Ropositories.Models.Employee employee)
        {
            if (employeeid != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(employeeid))
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
        public async Task<ActionResult<Ropositories.Models.Employee>> PostEmployee(Ropositories.Models.Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { employeeid = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{employeeid}")]
        public async Task<IActionResult> DeleteEmployee(string? employeeid)
        {
            var employee = await _context.Employees.FindAsync(employeeid);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int? employeeid)
        {
            return _context.Employees.Any(e => e.EmployeeId == employeeid);
        }
    }

}
