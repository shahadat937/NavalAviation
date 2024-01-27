using MediatR;
using SchoolManagement.Application.DTOs.CodeValueType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CodeValueTypes.Requests.Commands
{
    public class CreateCodeValueTypeCommand : IRequest<BaseCommandResponse> 
    {
        public CreateCodeValueTypeDto CodeValueTypeDto { get; set; }      

    }
}
