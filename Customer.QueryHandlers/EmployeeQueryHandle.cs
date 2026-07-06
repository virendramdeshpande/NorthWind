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
        public EmployeeQueryHandle(NorthwindContext northwindContext)
        {
            _northwindContext = northwindContext;
        }
        public async Task<Result<EmployeeResult>> Handle(EmployeeQuery request, CancellationToken cancellationToken)
        {
            var entity = await _northwindContext.Employees.Where(e => e.FirstName == "Nancy").FirstOrDefaultAsync(cancellationToken);

            Result<EmployeeResult> obj = new Result<EmployeeResult>();

            obj.isSuccessful = true;
            obj.exception = null;
            obj.data = new EmployeeResult
            {
                EmployeeId = entity.EmployeeId,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Title = entity.Title
            };
            return obj;

        }
    }
}
