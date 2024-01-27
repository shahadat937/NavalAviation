using MediatR;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Commands
{
    public class DeleteGseItemNameCommand : IRequest
    {
        public int GseItemNameId { get; set; }
    }
}
