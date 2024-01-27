using SchoolManagement.Application.DTOs.EmployeeType;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands
{
    public class CreateEmployeeTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateEmployeeTypeDto EmployeeTypeDto { get; set; }

    }
}
