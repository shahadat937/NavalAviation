using MediatR;
using SchoolManagement.Application.DTOs.ReminderType;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Commands
{
    public class UpdateReminderTypeCommand : IRequest<Unit>
    {
        public ReminderTypeDto ReminderTypeDto { get; set; }
    }
}
