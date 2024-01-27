using SchoolManagement.Application.DTOs.EmployeeType;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands
{
    public class UpdateEmployeeTypeCommand : IRequest<Unit>
    {
        public EmployeeTypeDto EmployeeTypeDto { get; set; }

    }
}
