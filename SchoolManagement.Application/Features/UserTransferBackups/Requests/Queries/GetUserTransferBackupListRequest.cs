using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries
{
    public class GetUserTransferBackupListRequest : IRequest<PagedResult<UserTransferBackupDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
