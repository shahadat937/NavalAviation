using MediatR;
using SchoolManagement.Application.DTOs.DemandDocs;

namespace SchoolManagement.Application.Features.DemandDocs.Requests.Queries
{
    public class GetDemandDocDetailRequest : IRequest<DemandDocDto>
    {
        public int DemandDocId { get; set; }
    }
}
