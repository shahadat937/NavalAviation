using MediatR;
using SchoolManagement.Application.DTOs.AccountType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.AccountTypes.Requests.Queries
{
    public class GetAccountTypeListRequest : IRequest<PagedResult<AccountTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
