using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.PresentBillets.Requests.Queries
{
    public class GetSelectedPresentBilletRequest : IRequest<List<SelectedModel>>
    {
    }
} 
