using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetSpPersonalStateRequest : IRequest<object>
    {
        //public DateTime? Current { get; set; }
        public int DepartmentId { get; set; }
    }
}
