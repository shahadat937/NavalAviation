using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.EquipmentName;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.EquipmentNames.Requests.Queries
{
    public class GetEquipmentNameListRequest : IRequest<PagedResult<EquipmentNameDto>>
    {
        public QueryParams QueryParams { get; set; }
    } 
}
