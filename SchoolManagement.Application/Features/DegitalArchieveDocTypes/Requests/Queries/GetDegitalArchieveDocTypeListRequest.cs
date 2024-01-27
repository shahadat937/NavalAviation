using MediatR;
using SchoolManagement.Application.DTOs.DegitalArchieveDocType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Queries
{
    public class GetDegitalArchieveDocTypeListRequest : IRequest<PagedResult<DegitalArchieveDocTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
