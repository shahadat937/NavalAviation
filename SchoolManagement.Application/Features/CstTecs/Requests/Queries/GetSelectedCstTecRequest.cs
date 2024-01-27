using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Queries
{
    public class GetSelectedCstTecRequest : IRequest<List<SelectedModel>>
    {
    }
} 
