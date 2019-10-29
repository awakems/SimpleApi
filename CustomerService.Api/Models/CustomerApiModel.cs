using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Api.Models
{
    public class CustomerApiModel
    {
        [JsonProperty("customerID")]
        public long ID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("email")]
        public string ContactEmail { get; set; }
        [JsonProperty("mobile")]
        public int? MobileNo { get; set; }
        [JsonProperty("transactions")]
        public List<TransactionApiModel> Transactions { get; set; }
    }
}