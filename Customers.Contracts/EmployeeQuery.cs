using MediatR;
using SOLID.Framwork;

namespace Customers.Contracts
{
    public class EmployeeQuery : IRequest<Result<EmployeeResult>>
    {
        public string CustId { get; set; }
    }

    public class EmployeeResult
    {
        public int EmployeeId { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string Title { get; set; }
    }
}
