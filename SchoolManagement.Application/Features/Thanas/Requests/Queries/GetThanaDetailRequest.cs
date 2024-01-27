using SchoolManagement.Application.DTOs.Thana;
using MediatR;

namespace SchoolManagement.Application.Features.Thanas.Requests.Queries
{
    public class GetThanaDetailRequest : IRequest<ThanaDto>
    {
        public int ThanaId { get; set; }
    }
}
