using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Queries
{
    public class GetSelectedDemandDocRequest : IRequest<List<SelectedModel>>
    {
    }
} 
