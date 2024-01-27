using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Commands
{
    public class DeleteEmployeeTypeCommand : IRequest
    {
        public int EmployeeTypeId { get; set; }
    }
}
