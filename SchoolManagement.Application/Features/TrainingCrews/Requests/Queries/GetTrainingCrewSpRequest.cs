using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetTrainingCrewSpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
