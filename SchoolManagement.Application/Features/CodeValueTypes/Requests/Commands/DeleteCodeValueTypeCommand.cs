using MediatR;

namespace SchoolManagement.Application.Features.CodeValueTypes.Requests.Commands
{
    public class DeleteCodeValueTypeCommand : IRequest 
    {  
        public int CodeValueTypeId { get; set; }
    }
}
