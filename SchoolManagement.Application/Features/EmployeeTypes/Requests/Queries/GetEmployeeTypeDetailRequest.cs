using SchoolManagement.Application.DTOs.EmployeeType;
using MediatR;

namespace SchoolManagement.Application.Features.EmployeeTypes.Requests.Queries
{
    public class GetEmployeeTypeDetailRequest : IRequest<EmployeeTypeDto>
    {
        public int EmployeeTypeId { get; set; }
    }
}
