using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetMaintenenceStateForToolsSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
    }
}
