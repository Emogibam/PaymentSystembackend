using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.RequestDTOs
{
    public class CustomerRegistrationDTO
    {
        public string NationalId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CustomerNumber { get; set; }
    }
}
