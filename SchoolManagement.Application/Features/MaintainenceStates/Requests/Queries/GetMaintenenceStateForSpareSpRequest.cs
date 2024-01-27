using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetMaintenenceStateForSpareSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
    }
}
