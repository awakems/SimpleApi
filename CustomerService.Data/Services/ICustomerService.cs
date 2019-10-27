using CustomerService.Data.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services
{
    public interface ICustomerService
    {
        CustomerServiceModel GetCustomerBy(int id);
        CustomerServiceModel GetCustomerBy(string email);
        CustomerServiceModel GetCustomerBy(int id, string email);
    }
}
