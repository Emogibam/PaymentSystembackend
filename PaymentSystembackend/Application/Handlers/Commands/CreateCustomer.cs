using Application.Commands;
using Domain.DTOs.RequestDTOs;
using Domain.DTOs.ResponseDTOs;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Commands
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, ApiResponse<CustomerRegistrationResponseDTO>>
    {
        private readonly UserManager<User> _userManager;
        private readonly PaymentContext _context;

        public CreateCustomerHandler(UserManager<User> userManager, PaymentContext context)
        {
            _userManager = userManager;
            _context = context;
        }


        public Task<ApiResponse<CustomerRegistrationResponseDTO>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
