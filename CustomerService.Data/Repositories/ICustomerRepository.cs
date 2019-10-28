namespace CustomerService.Data.Repositories
{
    public interface ICustomerRepository
    {
        Customer GetCustomerBy(int id);
        Customer GetCustomerBy(string email);
        Customer GetCustomerBy(int id, string email);
    }
}
