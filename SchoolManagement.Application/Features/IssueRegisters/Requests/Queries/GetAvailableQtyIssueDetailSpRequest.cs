using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetAvailableQtySpRequest : IRequest<object>
    {
        public int DepartmentId { get; set; }
    }
}
