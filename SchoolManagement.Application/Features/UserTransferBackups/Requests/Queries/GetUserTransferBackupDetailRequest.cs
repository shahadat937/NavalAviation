using MediatR;
using SchoolManagement.Application.DTOs.UserTransferBackups;

namespace SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries
{
    public class GetUserTransferBackupDetailRequest : IRequest<UserTransferBackupDto>
    {
        public int Id { get; set; }
    }
}
