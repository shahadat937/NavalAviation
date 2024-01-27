using MediatR;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Commands
{
    public class DeleteReminderTypeCommand : IRequest
    {
        public int ReminderTypeId { get; set; }
    }
}
