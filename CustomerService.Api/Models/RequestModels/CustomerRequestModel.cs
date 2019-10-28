using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Api.Models.RequestModels
{

    public class CustomerRequestModel
    {
        public int? customerID { get; set; }
        public string email { get; set; }
    }
}