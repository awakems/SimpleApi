using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services.ServiceModels.ServiceRequestModels
{
    public class CustomerServiceRequestModel
    {
        public int? customerID { get; set; }
        public string email { get; set; }
    }
}
