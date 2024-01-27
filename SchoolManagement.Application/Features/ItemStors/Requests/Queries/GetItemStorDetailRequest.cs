using MediatR;
using SchoolManagement.Application.DTOs.ItemStor;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Queries
{
    public class GetItemStorDetailRequest : IRequest<ItemStorDto>
    {
        public int ItemStorId { get; set; }
    }
}
