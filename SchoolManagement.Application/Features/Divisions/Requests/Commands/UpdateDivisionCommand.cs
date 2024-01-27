using SchoolManagement.Application.DTOs.Division;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Requests.Commands
{
    public class UpdateDivisionCommand : IRequest<Unit>
    {
        public DivisionDto DivisionDto { get; set; }

    }
}
