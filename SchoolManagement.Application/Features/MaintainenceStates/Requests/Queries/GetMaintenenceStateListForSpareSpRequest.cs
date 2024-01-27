using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetMaintenenceStateListForSpareSpRequest : IRequest<object>
    {
        public int DepartmentNameId { get; set; }
    }
}
