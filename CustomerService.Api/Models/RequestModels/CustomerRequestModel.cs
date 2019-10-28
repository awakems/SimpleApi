using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomerService.Api.Models.RequestModels
{
    public class CustomerRequestModel : IValidatableObject
    {
        public int? customerID { get; set; }
        public string email { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();

            if (customerID == null && email == null)
            {
                results.Add(new ValidationResult("Invalid Customer ID"));
                results.Add(new ValidationResult("Invalid Email"));
            }

            if (customerID != null && customerID <= 0)
            {
                results.Add(new ValidationResult("Invalid Customer ID"));
            }

            if (email != null && email.Length <= 25)
            {
                if (!ValidEmail(email)) results.Add(new ValidationResult("Invalid Email"));
            }

            if (email != null && email.Length > 25)
            {
                results.Add(new ValidationResult("Invalid Email"));
            }

            return results;
        }

        private bool ValidEmail(string emailString)
        {
            bool isEmail = Regex.IsMatch(emailString, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            return isEmail;
        }
    }
}