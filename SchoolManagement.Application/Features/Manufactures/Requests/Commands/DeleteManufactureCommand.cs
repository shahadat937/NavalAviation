using MediatR;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Commands
{
    public class DeleteManufactureCommand : IRequest
    {
        public int ManufactureId { get; set; }
    }
}
