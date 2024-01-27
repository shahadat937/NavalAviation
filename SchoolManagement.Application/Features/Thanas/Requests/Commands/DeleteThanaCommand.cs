using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Requests.Commands
{
    public class DeleteThanaCommand : IRequest
    {
        public int ThanaId { get; set; }
    }
}
