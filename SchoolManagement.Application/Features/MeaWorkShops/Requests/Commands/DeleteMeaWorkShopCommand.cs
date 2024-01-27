using MediatR;

namespace SchoolManagement.Application.Features.MeaWorkShops.Requests.Commands
{
    public class DeleteMeaWorkShopCommand : IRequest
    {
        public int MeaWorkShopId { get; set; }
    }
}
