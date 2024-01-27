using MediatR;
using SchoolManagement.Application.DTOs.SourceOfSupply;

namespace SchoolManagement.Application.Features.SourceOfSupplys.Requests.Queries
{
    public class GetSourceOfSupplyDetailRequest : IRequest<SourceOfSupplyDto>
    {
        public int SourceOfSupplyId { get; set; }
    }
}
