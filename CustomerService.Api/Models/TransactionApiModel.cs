using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerService.Api.Models
{
    public class TransactionApiModel
    {
        [JsonProperty("id")]
        public decimal ID { get; set; }
        [JsonProperty("date")]
        public string TransactionDateTime { get; set; }
        [JsonProperty("amount")]
        public string Amount { get; set; }
        [JsonProperty("currency")]
        public string CurrencyCode { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}