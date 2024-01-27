using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetSelectedTrainingCrewRequest : IRequest<List<SelectedModel>>
    {
    }
}
