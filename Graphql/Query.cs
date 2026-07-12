using Ropositories.Models;

namespace Graphql
{
    public class Query
    {

        [UseProjection]
        public IQueryable<Customer> GetCustomers(
            NorthwindContext db)
        {
            return db.Customers;
        }


    }
}
