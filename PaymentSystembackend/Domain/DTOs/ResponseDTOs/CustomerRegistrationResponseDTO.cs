using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.ResponseDTOs
{
    public class CustomerRegistrationResponseDTO 
    {
        public string CustomerId { get; set; }
        public string Message { get; set; }
    }
}
