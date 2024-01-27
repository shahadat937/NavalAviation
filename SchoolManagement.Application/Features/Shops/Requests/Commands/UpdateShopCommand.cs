using SchoolManagement.Application.DTOs.Shop;
using MediatR;

namespace SchoolManagement.Application.Features.Shops.Requests.Commands
{
    public class UpdateShopCommand : IRequest<Unit>
    {
        public ShopDto ShopDto { get; set; }

    }
}
