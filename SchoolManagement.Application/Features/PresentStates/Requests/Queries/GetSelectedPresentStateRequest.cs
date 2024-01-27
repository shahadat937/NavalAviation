using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PresentStates.Requests.Queries
{
    public class GetSelectedPresentStateRequest : IRequest<List<SelectedModel>>
    {
    }
} 
