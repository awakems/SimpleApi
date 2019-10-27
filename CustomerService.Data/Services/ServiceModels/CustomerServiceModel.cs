using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services.ServiceModels
{
    public class CustomerServiceModel
    {
        public decimal ID { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public decimal? MobileNo { get; set; }
        public List<TransactionServiceModel> Transactions { get; set; } = new List<TransactionServiceModel>();
    }
}
