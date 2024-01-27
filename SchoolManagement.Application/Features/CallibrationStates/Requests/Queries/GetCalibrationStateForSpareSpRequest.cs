using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetCalibrationStateForSpareSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
    }
}
