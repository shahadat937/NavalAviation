using MediatR;

namespace SchoolManagement.Application.Features.Shops.Requests.Commands
{
    public class DeleteShopCommand : IRequest
    {
        public int ShopId { get; set; }
    }
}
