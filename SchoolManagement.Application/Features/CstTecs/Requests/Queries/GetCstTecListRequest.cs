using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Queries
{
    public class GetCstTecListRequest : IRequest<PagedResult<CstTecDto>>
    {
        public QueryParams QueryParams { get; set; }
    } 
}
