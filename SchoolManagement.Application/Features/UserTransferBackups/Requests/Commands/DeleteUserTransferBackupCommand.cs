using MediatR;

namespace SchoolManagement.Application.Features.UserTransferBackups.Requests.Commands
{
    public class DeleteUserTransferBackupCommand : IRequest
    {
        public int Id { get; set; }
    }
} 
