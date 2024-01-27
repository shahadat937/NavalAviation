using MediatR;
using SchoolManagement.Application.DTOs.MeaWorkShop;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands
{
    public class CreateMeaWorkShopCommand : IRequest<BaseCommandResponse>
    {
        public CreateMeaWorkShopDto MeaWorkShopDto { get; set; }
    }
}
