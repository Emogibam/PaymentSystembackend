using Domain.DTOs.RequestDTOs;
using Domain.DTOs.ResponseDTOs;
using MediatR;

namespace Application.Commands
{
    public record CreateCustomerCommand(CustomerRegistrationDTO Customer) : IRequest<ApiResponse<CustomerRegistrationResponseDTO>>;
}
