using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.UserTransferBackups.Requests.Queries
{
    public class GetSelectedUserTransferBackupRequest : IRequest<List<SelectedModel>>
    {
    }
} 
