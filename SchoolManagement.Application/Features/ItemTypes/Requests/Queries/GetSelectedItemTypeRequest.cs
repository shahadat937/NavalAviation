using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Queries
{
    public class GetSelectedItemTypeRequest : IRequest<List<SelectedModel>>
    {
    }
} 
