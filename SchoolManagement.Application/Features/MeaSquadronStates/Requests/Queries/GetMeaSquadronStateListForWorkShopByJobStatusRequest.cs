using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MeaSquadronState;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MeaSquadronStates.Requests.Queries
{
    public class GetMeaSquadronStateListForWorkShopByJobStatusRequest : IRequest<PagedResult<MeaSquadronStateDto>>
    {
        public QueryParams QueryParams { get; set; }
        //public int DepartmentNameId { get; set; }
     }
}
