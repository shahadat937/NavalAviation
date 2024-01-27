using MediatR;
using SchoolManagement.Application.DTOs.ReminderType;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Commands
{
    public class CreateReminderTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateReminderTypeDto ReminderTypeDto { get; set; }
    }
}
