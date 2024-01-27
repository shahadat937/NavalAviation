using MediatR;

namespace SchoolManagement.Application.Features.LifeLimitItems.Requests.Commands
{
    public class DeleteLifeLimitItemCommand : IRequest
    {
        public int LifeLimitItemId { get; set; }
    }
}
