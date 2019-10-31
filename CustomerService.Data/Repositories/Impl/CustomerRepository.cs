using System.Linq;
using System.Data.Entity;
using Z.EntityFramework.Plus;

namespace CustomerService.Data.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        DbEntities _context = new DbEntities();

        public Customer GetCustomerBy(int id)
        {
            return _context.Customers.IncludeFilter(x => x.Transactions.OrderByDescending(z => z.TransactionDateTime).Take(5)).FirstOrDefault(y => y.ID == id);
        }

        public Customer GetCustomerBy(string email)
        {
            return _context.Customers.IncludeFilter(x => x.Transactions.OrderByDescending(z => z.TransactionDateTime).Take(5)).FirstOrDefault(x => x.ContactEmail == email);
        }

        public Customer GetCustomerBy(int id, string email)
        {
            return _context.Customers.IncludeFilter(x => x.Transactions.OrderByDescending(z => z.TransactionDateTime).Take(5)).FirstOrDefault(x => x.ID == id && x.ContactEmail == email);
        }

        public void Dispose() => _context.Dispose();

    }
}
