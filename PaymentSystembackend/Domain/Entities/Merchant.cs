using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Merchant : User
    {
        public string MerchantId { get; set; }

        [Required]
        public string BusinessId { get; set; }

        [Required]
        public string BusinessName { get; set; }

        [Required]
        public string ContactName 
        {
            get => FirstName;
            set => FirstName = value;
        }

        [Required]
        public string ContactSurname 
        {
            get => LastName;
            set => LastName = value; 
        }

        [Required]
        [DataType(DataType.Date)]
        [DateValidation(ErrorMessage = "The business must be at least 1 year old.")]
        public DateTime DateOfEstablishment { get; set; }

        [Required]
        public string MerchantNumber { get; set; }

        public decimal? AverageTransactionVolume { get; set; }

    }
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            if (date > DateTime.Now.AddYears(-1))
            {
                return new ValidationResult(ErrorMessage ?? "The business must be at least 1 year old.");
            }
            return ValidationResult.Success;
        }
    }
}
