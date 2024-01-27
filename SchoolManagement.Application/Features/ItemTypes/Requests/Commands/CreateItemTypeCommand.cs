using MediatR;
using SchoolManagement.Application.DTOs.ItemTypes;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Commands
{
    public class CreateItemTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemTypeDto ItemTypeDto { get; set; }
    }
}
