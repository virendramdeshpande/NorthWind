using Customers.Contracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ropositories.Models;
using SOLID.Framwork;

namespace Customer.QueryHandlers
{
    public class EmployeeQueryHandle : IRequestHandler<EmployeeQuery, Result<EmployeeResult>>
    {
        public NorthwindContext _northwindContext;
        Result<EmployeeResult> obj;
        public EmployeeQueryHandle(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public async Task<Result<EmployeeResult>> Handle(EmployeeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _northwindContext.Employees.Where(e => e.FirstName == "Nancy").FirstOrDefaultAsync(cancellationToken);

                obj = new Result<EmployeeResult>();

                obj.isSuccessful = true;
                obj.exception = null;
                obj.data = new EmployeeResult
                {
                    EmployeeId = entity.EmployeeId,
                    LastName = entity.LastName,
                    FirstName = entity.FirstName,
                    Title = entity.Title
                };

            }
            catch (Exception ex)
            {
                obj = new Result<EmployeeResult>();
                obj.isSuccessful = false;
                obj.exception = ex;
                obj.data = null;
                return obj;
            }
           
                return obj;
            
        }
    }
}
