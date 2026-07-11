using Ropositories.Models;

namespace NorthWind
{
    public class Query
    {
       
        [UseProjection]
        public  IQueryable<Customer> GetCustomers(
            NorthwindContext db)
        {
            return db.Customers;
        }

        
    }
}
