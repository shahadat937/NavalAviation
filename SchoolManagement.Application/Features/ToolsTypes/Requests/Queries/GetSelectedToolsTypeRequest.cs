using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ToolsTypes.Requests.Queries
{
    public class GetSelectedToolsTypeRequest : IRequest<List<SelectedModel>>
    {
    }
} 
