using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CodeValueTypes.Requests.Queries
{
    public class GetSelectedCodeValueTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
