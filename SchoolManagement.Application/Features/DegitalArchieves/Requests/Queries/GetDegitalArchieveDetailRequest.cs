using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieve;

namespace SchoolManagement.Application.Features.DegitalArchieves.Requests.Queries
{
    public class GetDegitalArchieveDetailRequest : IRequest<DegitalArchieveDto>
    {
        public int DegitalArchieveId { get; set; }
    }
}
