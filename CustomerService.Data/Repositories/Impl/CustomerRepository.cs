using System.Linq;

namespace CustomerService.Data.Repositories.Impl
{
    public class CustomerRepository : ICustomerRepository
    {
        DbEntities _context = new DbEntities();

        public Customer GetCustomerBy(int id)
        {
            var result = _context.Customers.Find(id);
            if (result == null) return null;
            return new Customer
            {
                ID = result.ID,
                ContactEmail = result.ContactEmail,
                MobileNo = result.MobileNo,
                Name = result.Name,
                Transactions = result.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList()
            };
        }

        public Customer GetCustomerBy(string email)
        {
            var result = _context.Customers.FirstOrDefault(x => x.ContactEmail == email);
            if (result == null) return null;
            return new Customer
            {
                ID = result.ID,
                ContactEmail = result.ContactEmail,
                MobileNo = result.MobileNo,
                Name = result.Name,
                Transactions = result.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList()
            };
        }

        public Customer GetCustomerBy(int id, string email)
        {
            var result = _context.Customers.FirstOrDefault(x => x.ID == id && x.ContactEmail == email);
            if (result == null) return null;
            return new Customer
            {
                ID = result.ID,
                ContactEmail = result.ContactEmail,
                MobileNo = result.MobileNo,
                Name = result.Name,
                Transactions = result.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList()
            };
        }

        public void Dispose() => _context.Dispose();

    }
}
