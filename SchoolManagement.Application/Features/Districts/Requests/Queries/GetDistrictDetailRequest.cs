using SchoolManagement.Application.DTOs.District;
using MediatR;

namespace SchoolManagement.Application.Features.Districts.Requests.Queries
{
    public class GetDistrictDetailRequest : IRequest<DistrictDto>
    {
        public int DistrictId { get; set; }
    }
}
