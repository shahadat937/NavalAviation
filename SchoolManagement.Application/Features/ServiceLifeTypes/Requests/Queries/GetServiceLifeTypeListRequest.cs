using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Queries
{
    public class GetServiceLifeTypeListRequest : IRequest<PagedResult<ServiceLifeTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
