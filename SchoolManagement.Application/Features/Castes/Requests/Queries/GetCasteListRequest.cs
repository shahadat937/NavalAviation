using SchoolManagement.Application.DTOs.Caste;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetCasteListRequest : IRequest<PagedResult<CasteDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
