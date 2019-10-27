using CustomerService.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        DbEntities _context = new DbEntities();

        public Customer GetCustomerBy(int id)
        {
            return _context.Customers.Find(id);
        }

        public Customer GetCustomerBy(string email)
        {
            return _context.Customers.FirstOrDefault(x => x.ContactEmail == email);
        }

        public Customer GetCustomerBy(int id, string email)
        {
            return _context.Customers.FirstOrDefault(x => x.ID == id && x.ContactEmail == email);
        }

        public void Dispose() => _context.Dispose();

    }
}
