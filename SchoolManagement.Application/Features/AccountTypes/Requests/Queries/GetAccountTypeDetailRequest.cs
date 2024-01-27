using MediatR;
using SchoolManagement.Application.DTOs.AccountType;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Queries
{
    public class GetAccountTypeDetailRequest : IRequest<AccountTypeDto>
    {
        public int AccountTypeId { get; set; }
    }
}
