using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetCalibrationStateListForToolsSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
        public string SearchText { get; set; }
    } 
}
