using MediatR;
using SchoolManagement.Application.DTOs.Manufacture;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Commands
{
    public class UpdateManufactureCommand : IRequest<Unit>
    {
        public ManufactureDto ManufactureDto { get; set; }
    }
}
