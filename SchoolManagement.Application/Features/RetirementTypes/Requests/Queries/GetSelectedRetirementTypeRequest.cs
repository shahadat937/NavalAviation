using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.RetirementTypes.Requests.Queries
{
    public class GetSelectedRetirementTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
