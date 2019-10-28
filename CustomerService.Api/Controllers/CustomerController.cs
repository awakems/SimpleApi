using AutoMapper;
using CustomerService.Api.Filters;
using CustomerService.Api.Models;
using CustomerService.Api.Models.RequestModels;
using CustomerService.Data.Services;
using CustomerService.Data.Services.ServiceModels.ServiceRequestModels;
using System;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace CustomerService.Api.Controllers
{
    public class CustomerController : ApiController
    {
        ICustomerService _customerService;
        IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        
        /// <summary>
        /// Depends on request params returns Customer with last Transactions.
        /// 1) by id - no transactions
        /// 2) by email - one last transaction
        /// 3) both - five last transactions
        /// </summary>
        /// <param name="requestModel">request model</param>
        /// <returns>Customer and last transactions</returns>
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Post([FromBody] CustomerRequestModel requestModel)
        {
            try
            {
                var requestService = _mapper.Map<CustomerServiceRequestModel>(requestModel);
                var serviceModel = _customerService.GetCustomer(requestService);
                if (serviceModel == null) return BadRequest("No inquiry criteria");
                var result = _mapper.Map<CustomerApiModel>(serviceModel);
                return Ok<CustomerApiModel>(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }
    }
}
