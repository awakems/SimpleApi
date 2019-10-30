using AutoMapper;
using CustomerService.Data.Repositories;
using CustomerService.Data.Services.ServiceModels;
using CustomerService.Data.Services.ServiceModels.ServiceRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services.Impl
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepository _customerRepository;
        IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public CustomerServiceModel GetCustomer(CustomerServiceRequestModel requestParams)
        {
            var id = requestParams.customerID;
            var email = requestParams.email;

            if (requestParams == null) throw new ArgumentNullException();
            
            //Case with both parameters
            if (id != null && email != null)
            {
                var customer = _customerRepository.GetCustomerBy((int)id, email);
                if (customer == null) return null;
                var result = _mapper.Map<CustomerServiceModel>(customer);
                return result;
            }
            //case with id present
            else if (id != null)
            {
                var customer = _customerRepository.GetCustomerBy((int)id);
                if (customer == null) return null;
                var result = _mapper.Map<CustomerServiceModel>(customer);
                return result;
            }
            //case with email present
            else
            {
                var customer = _customerRepository.GetCustomerBy(email);
                if (customer == null) return null;
                var result = _mapper.Map<CustomerServiceModel>(customer);
                return result;
            }
        }
    }
}
