using SchoolManagement.Application.DTOs.Religion;
using MediatR;

namespace SchoolManagement.Application.Features.Religions.Requests.Queries
{
    public class GetReligionDetailRequest : IRequest<ReligionDto>
    {
        public int ReligionId { get; set; }
    }
}
