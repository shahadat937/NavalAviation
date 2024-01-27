using MediatR;
using SchoolManagement.Application.DTOs.SourceOfSupply;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Commands
{
    public class CreateSourceOfSupplyCommand : IRequest<BaseCommandResponse>
    {
        public CreateSourceOfSupplyDto SourceOfSupplyDto { get; set; }
    }
}
