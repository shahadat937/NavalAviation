using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.AppFeature.Requests.Queries
{
    public class GetSelectedFeatureByTypeRequest : IRequest<List<SelectedModel>>
    {
        public string Type { get; set; }    
    }
}
