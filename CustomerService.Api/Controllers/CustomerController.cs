using AutoMapper;
using CustomerService.Api.Filters;
using CustomerService.Api.Models;
using CustomerService.Api.Models.RequestModels;
using CustomerService.Data.Services;
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

        
        [HttpPost]
        [ValidateModel]
        public IHttpActionResult Post([FromBody] CustomerRequestModel requestModel)
        {
            try
            {
                return Ok("Vse OK");
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }
        }

        /// <summary>
        /// Get customer by id from database
        /// </summary>
        /// <param name="customerID"> Customer id</param>
        /// <returns>Returns Customer object without Transactions</returns>
        [HttpGet]
        public IHttpActionResult Get([FromUri]int customerID)
        {
            try
            {
                if (customerID <= 0) return BadRequest("Invalid Customer ID ");
                var serviceModel = _customerService.GetCustomerBy(customerID);
                if (serviceModel == null) return BadRequest("No inquiry criteria");
                var result = _mapper.Map<CustomerApiModel>(serviceModel);
                return Ok<CustomerApiModel>(result);
            }
            catch (Exception e)
            {
                return InternalServerError(e);
            }

        }

        /// <summary>
        /// Get customer by email from database
        /// </summary>
        /// <param name="email">Customer Email</param>
        /// <returns>returns Customer object with one last Transactions</returns>
        //[HttpGet]
        //public IHttpActionResult Get([FromUri]string email)
        //{
        //    try
        //    {
        //        if (!ValidEmail(email)) return BadRequest("Invalid Email");
        //        var serviceModel = _customerService.GetCustomerBy(email);
        //        if (serviceModel == null) return BadRequest("No inquiry criteria");
        //        var result = _mapper.Map<CustomerApiModel>(serviceModel);
        //        return Ok<CustomerApiModel>(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return InternalServerError(e);
        //    }

        //}

        /// <summary>
        /// Get customer by email and customerID from database
        /// </summary>
        /// <param name="customerID"></param>
        /// <param name="email"></param>
        /// <returns>returns Customer object with 5 last Transactions</returns>
        //[HttpGet]
        //public IHttpActionResult Get([FromUri] int customerID, string email)
        //{
        //    try
        //    {
        //        if (customerID <= 0) return BadRequest("Invalid Customer ID ");
        //        if (!ValidEmail(email)) return BadRequest("Invalid Email");
        //        var serviceModel = _customerService.GetCustomerBy(customerID, email);
        //        if (serviceModel == null) return BadRequest("No inquiry criteria");
        //        var result = _mapper.Map<CustomerApiModel>(serviceModel);
        //        return Ok<CustomerApiModel>(result);
        //    }
        //    catch (Exception e)
        //    {
        //        return InternalServerError(e);
        //    }

        //}

        
    }
}
