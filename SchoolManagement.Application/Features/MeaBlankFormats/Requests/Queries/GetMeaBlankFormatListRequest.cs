using MediatR;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries
{
    public class GetMeaBlankFormatListRequest : IRequest<PagedResult<MeaBlankFormatDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
