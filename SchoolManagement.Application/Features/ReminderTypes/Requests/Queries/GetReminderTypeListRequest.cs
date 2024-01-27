using MediatR;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Queries
{
    public class GetReminderTypeListRequest : IRequest<PagedResult<ReminderTypeDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
