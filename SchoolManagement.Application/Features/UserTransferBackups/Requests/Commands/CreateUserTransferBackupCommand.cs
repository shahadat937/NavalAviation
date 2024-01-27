using MediatR;
using SchoolManagement.Application.DTOs.UserTransferBackups;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.UserTransferBackups.Requests.Commands
{
    public class CreateUserTransferBackupCommand : IRequest<BaseCommandResponse>
    {
        public List<CreateUserTransferBackupDto> UserTransferBackupDto { get; set; }
    }
}
