using MediatR;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands
{
    public class DeleteSourceOfSupplyCommand : IRequest
    {
        public int SourceOfSupplyId { get; set; }
    }
}
