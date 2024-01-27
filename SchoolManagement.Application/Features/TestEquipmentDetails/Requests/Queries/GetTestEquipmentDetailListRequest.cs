using SchoolManagement.Application.DTOs.TestEquipmentDetail;
using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TestEquipmentDetails.Requests.Queries
{
    public class GetTestEquipmentDetailListRequest : IRequest<PagedResult<TestEquipmentDetailDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
