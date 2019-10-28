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
                customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList();
                var result = _mapper.Map<CustomerServiceModel>(customer);
                return result;
            }
            //case with id present
            else if (id != null)
            {
                var customer = _customerRepository.GetCustomerBy((int)id);
                if (customer == null) return null;

                return new CustomerServiceModel
                {
                    ID = customer.ID,
                    ContactEmail = customer.ContactEmail,
                    Name = customer.Name,
                    MobileNo = customer.MobileNo
                };
            }
            //case with email present
            else
            {
                var customer = _customerRepository.GetCustomerBy(email);
                if (customer == null) return null;
                customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(1).ToList();
                var result = _mapper.Map<CustomerServiceModel>(customer);
                return result;
            }
        }

        public CustomerServiceModel GetCustomerBy(int id)
        {
            var customer = _customerRepository.GetCustomerBy(id);
            if (customer == null) return null;

            return new CustomerServiceModel
            {
                ID = customer.ID,
                ContactEmail = customer.ContactEmail,
                Name = customer.Name,
                MobileNo = customer.MobileNo
            };
        }

        public CustomerServiceModel GetCustomerBy(string email)
        {
            var customer = _customerRepository.GetCustomerBy(email);
            if (customer == null) return null;
            customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(1).ToList();
            var result = _mapper.Map<CustomerServiceModel>(customer);
            return result;
        }

        public CustomerServiceModel GetCustomerBy(int id, string email)
        {
            var customer = _customerRepository.GetCustomerBy(id, email);
            if (customer == null) return null;
            customer.Transactions = customer.Transactions.OrderByDescending(x => x.TransactionDateTime).Take(5).ToList();
            var result = _mapper.Map<CustomerServiceModel>(customer);
            return result;
        }
    }
}
