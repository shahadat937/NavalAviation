using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Commands
{
    public class DeleteItemStorCommand : IRequest
    {
        public int ItemStorId { get; set; }
    }
}
