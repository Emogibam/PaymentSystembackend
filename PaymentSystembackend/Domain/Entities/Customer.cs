using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer : User
    {
        public string CustomerId { get; set; }

        [Required]
        public string NationalId { get; set; }

        [Required]
        public string Name
        {
            get => FirstName;
            set => FirstName = value;
        }

        [Required]
        public string Surname
        {
            get => LastName;
            set => LastName = value;
        }

        [Required]
        [DataType(DataType.Date)]
        [AgeValidation(ErrorMessage = "The customer must be of legal age.")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string CustomerNumber { get; set; }

        public ICollection<TransactionHistory>? TransactionHistory { get; set; }
    }

    public class AgeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime date = Convert.ToDateTime(value);
            int age = DateTime.Now.Year - date.Year;
            if (date > DateTime.Now.AddYears(-age)) age--;
            if (age < 18) // Assuming 18 is the legal age
            {
                return new ValidationResult(ErrorMessage ?? "The customer must be of legal age.");
            }
            return ValidationResult.Success;
        }
    }
}
