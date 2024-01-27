using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ConditionOfItems.Requests.Queries
{
    public class GetSelectedConditionOfItemRequest : IRequest<List<SelectedModel>>
    {
    }
} 
 