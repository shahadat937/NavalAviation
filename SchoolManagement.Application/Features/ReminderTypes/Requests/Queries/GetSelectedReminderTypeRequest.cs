using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ReminderTypes.Requests.Queries
{
    public class GetSelectedReminderTypeRequest : IRequest<List<SelectedModel>>
    {
    }
}
