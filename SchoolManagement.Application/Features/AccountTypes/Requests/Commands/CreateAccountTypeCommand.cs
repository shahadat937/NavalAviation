using MediatR;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Commands
{
    public class CreateAccountTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateAccountTypeDto AccountTypeDto { get; set; }
    }
}
