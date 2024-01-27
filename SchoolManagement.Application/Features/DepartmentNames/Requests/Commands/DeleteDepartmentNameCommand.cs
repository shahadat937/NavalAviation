using MediatR;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Commands
{
    public class DeleteDepartmentNameCommand : IRequest
    {
        public int DepartmentNameId { get; set; }
    }
}
