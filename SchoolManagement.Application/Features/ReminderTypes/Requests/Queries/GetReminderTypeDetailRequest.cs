using MediatR;
using SchoolManagement.Application.DTOs.ReminderType;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Queries
{
    public class GetReminderTypeDetailRequest : IRequest<ReminderTypeDto>
    {
        public int ReminderTypeId { get; set; }
    }
}
