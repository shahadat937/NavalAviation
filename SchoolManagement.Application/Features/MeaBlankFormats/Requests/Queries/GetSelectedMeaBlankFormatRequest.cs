using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries
{
    public class GetSelectedMeaBlankFormatRequest : IRequest<List<SelectedModel>>
    {
    }
}
