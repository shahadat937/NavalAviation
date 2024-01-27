using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetCalibrationStateForToolsSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
       // public string SearchText { get; set; }
    }
}
