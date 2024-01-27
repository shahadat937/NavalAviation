using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Attendences.Requests.Queries
{
    public class GetSelectedAttendenceRequest : IRequest<List<SelectedModel>>
    {
    }
}
