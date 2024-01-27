using MediatR;
using SchoolManagement.Application.DTOs.DepartmentName;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Commands
{
    public class UpdateDepartmentNameCommand : IRequest<Unit>
    {
        public DepartmentNameDto DepartmentNameDto { get; set; }
    }
}
