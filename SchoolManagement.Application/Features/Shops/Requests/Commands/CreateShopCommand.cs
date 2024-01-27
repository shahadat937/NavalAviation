using SchoolManagement.Application.DTOs.Shop;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Shops.Requests.Commands
{
    public class CreateShopCommand : IRequest<BaseCommandResponse>
    {
        public CreateShopDto ShopDto { get; set; }

    }
}
