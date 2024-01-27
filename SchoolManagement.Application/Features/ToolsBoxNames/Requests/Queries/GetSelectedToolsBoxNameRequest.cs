using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsBoxNames.Requests.Queries
{
    public class GetSelectedToolsBoxNameRequest : IRequest<List<SelectedModel>>
    {
    }
} 
 