using MediatR;
using SchoolManagement.Application.DTOs.Denos;

namespace SchoolManagement.Application.Features.Denos.Requests.Queries
{
    public class GetDenoDetailRequest : IRequest<DenoDto>
    {
        public int DenoId { get; set; }
    }
}
