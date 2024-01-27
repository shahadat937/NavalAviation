using MediatR;
using SchoolManagement.Application.DTOs.Manufacture;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Commands
{
    public class CreateManufactureCommand : IRequest<BaseCommandResponse>
    {
        public CreateManufactureDto ManufactureDto { get; set; }
    }
}
