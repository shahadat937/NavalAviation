using MediatR;

namespace SchoolManagement.Application.Features.TrainingCrews.Requests.Queries
{
    public class GetSpPersonalStateTotalCountRequestByDepartmentId : IRequest<object>
    {
      public int DepartmentNameId { get; set; }
    }
}
