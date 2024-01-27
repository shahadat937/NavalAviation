using MediatR;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Commands
{
    public class ApprovedItemStorCommand : IRequest 
    {
        public int ItemStorId { get; set; } 
    }
}
