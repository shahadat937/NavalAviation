using MediatR;
using SchoolManagement.Application.DTOs.GseItemName;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Commands
{
    public class CreateGseItemNameCommand : IRequest<BaseCommandResponse>
    {
        public CreateGseItemNameDto GseItemNameDto { get; set; }
    }
}
