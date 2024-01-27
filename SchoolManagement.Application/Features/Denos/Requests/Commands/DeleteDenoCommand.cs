using MediatR;

namespace SchoolManagement.Application.Features.Denos.Requests.Commands
{
    public class DeleteDenoCommand : IRequest
    {
        public int DenoId { get; set; }
    }
} 
