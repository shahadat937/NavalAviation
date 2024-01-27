using MediatR;

namespace SchoolManagement.Application.Features.AcStatuses.Requests.Queries
{
    public class GetSpAcStatusCountRequest : IRequest<object>
    {
        //public DateTime? Current { get; set; }
        public int DepartmentId { get; set; }
    }
}
