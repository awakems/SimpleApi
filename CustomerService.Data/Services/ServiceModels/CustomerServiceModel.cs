using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services.ServiceModels
{
    public class CustomerServiceModel
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public string ContactEmail { get; set; }
        public int? MobileNo { get; set; }
        public List<TransactionServiceModel> Transactions { get; set; } = new List<TransactionServiceModel>();
    }
}
