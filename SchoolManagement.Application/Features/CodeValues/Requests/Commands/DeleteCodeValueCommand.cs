using MediatR;

namespace SchoolManagement.Application.Features.CodeValues.Requests.Commands
{
    public class DeleteCodeValueCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
