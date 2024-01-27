using MediatR;
using SchoolManagement.Application.DTOs.Denos;

namespace SchoolManagement.Application.Features.Denos.Requests.Commands
{
    public class UpdateDenoCommand : IRequest<Unit>
    { 
        public DenoDto DenoDto { get; set; }
    }
}
 