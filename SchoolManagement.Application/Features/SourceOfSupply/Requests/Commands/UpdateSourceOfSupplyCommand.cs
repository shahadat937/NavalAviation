using MediatR;
using SchoolManagement.Application.DTOs.SourceOfSupply;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands
{
    public class UpdateSourceOfSupplyCommand : IRequest<Unit>
    {
        public SourceOfSupplyDto SourceOfSupplyDto { get; set; }
    }
}
