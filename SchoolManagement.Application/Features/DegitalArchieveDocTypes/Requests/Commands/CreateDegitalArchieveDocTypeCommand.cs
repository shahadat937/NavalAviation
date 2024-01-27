using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands
{
    public class CreateDegitalArchieveDocTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateDegitalArchieveDocTypeDto DegitalArchieveDocTypeDto { get; set; }
    }
}
