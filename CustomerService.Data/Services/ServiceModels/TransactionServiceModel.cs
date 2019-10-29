using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Data.Services.ServiceModels
{
    public class TransactionServiceModel
    {
        public long ID { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}
