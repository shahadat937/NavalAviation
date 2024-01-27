using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandAuthorities.Requests.Queries
{
    public class GetSelectedDemandAuthorityRequest : IRequest<List<SelectedModel>>
    {
    } 
} 
 