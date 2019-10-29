using CustomerService.Data.Services.ServiceModels;
using CustomerService.Data.Services.ServiceModels.ServiceRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services
{
    public interface ICustomerService
    {
        CustomerServiceModel GetCustomer(CustomerServiceRequestModel requestParams);
    }
}
