using MediatR;

namespace SchoolManagement.Application.Features.AirCraftFlyings.Requests.Queries
{
    public class GetAcceptanceListByPattNoSpRequest : IRequest<object>
    {
        //public DateTime? Current { get; set; }
        public int ItemDetailId { get; set; }
    }
}
