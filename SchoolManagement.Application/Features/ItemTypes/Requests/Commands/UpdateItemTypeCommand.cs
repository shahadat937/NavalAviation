using MediatR;
using SchoolManagement.Application.DTOs.ItemTypes;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Commands
{
    public class UpdateItemTypeCommand : IRequest<Unit>
    { 
        public ItemTypeDto ItemTypeDto { get; set; }
    }
}
