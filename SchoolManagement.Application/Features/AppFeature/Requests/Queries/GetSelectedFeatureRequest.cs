using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AppFeature.Requests.Queries
{
    public class GetSelectedFeatureRequest : IRequest<List<SelectedModel>>
    {
    }
}
