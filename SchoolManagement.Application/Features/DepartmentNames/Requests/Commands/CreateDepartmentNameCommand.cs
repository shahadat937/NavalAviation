using MediatR;
using SchoolManagement.Application.DTOs.DepartmentName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DepartmentNames.Requests.Commands
{
    public class CreateDepartmentNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateDepartmentNameDto DepartmentNameDto { get; set; }
    }
}
