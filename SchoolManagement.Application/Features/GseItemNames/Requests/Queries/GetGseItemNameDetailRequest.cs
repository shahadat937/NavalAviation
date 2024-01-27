using MediatR;
using SchoolManagement.Application.DTOs.GseItemName;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Queries
{
    public class GetGseItemNameDetailRequest : IRequest<GseItemNameDto>
    {
        public int GseItemNameId { get; set; }
    }
}
