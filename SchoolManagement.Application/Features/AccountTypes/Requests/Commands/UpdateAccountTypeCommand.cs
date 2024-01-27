using MediatR;
using SchoolManagement.Application.DTOs.AccountType;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Commands
{
    public class UpdateAccountTypeCommand : IRequest<Unit>
    {
        public AccountTypeDto AccountTypeDto { get; set; }
    }
}
