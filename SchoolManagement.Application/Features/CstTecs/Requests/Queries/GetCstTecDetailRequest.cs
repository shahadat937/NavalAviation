using MediatR;
using SchoolManagement.Application.DTOs.CstTec;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Queries
{
    public class GetCstTecDetailRequest : IRequest<CstTecDto>
    {
        public int CstTecId { get; set; }
    }
}
