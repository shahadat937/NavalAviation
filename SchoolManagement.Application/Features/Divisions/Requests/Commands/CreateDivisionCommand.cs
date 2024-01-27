using SchoolManagement.Application.DTOs.Division;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Requests.Commands
{
    public class CreateDivisionCommand : IRequest<BaseCommandResponse>
    {
        public CreateDivisionDto DivisionDto { get; set; }

    }
}
