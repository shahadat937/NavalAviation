using MediatR;
using SchoolManagement.Application.DTOs.CodeValueType;

namespace SchoolManagement.Application.Features.CodeValueTypes.Requests.Commands
{
    public class UpdateCodeValueTypeCommand : IRequest<Unit>  
    { 
        public CodeValueTypeDto CodeValueTypeDto { get; set; }     
    }
}
