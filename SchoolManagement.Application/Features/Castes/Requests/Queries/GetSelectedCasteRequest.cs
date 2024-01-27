using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetSelectedCasteRequest : IRequest<List<SelectedModel>>
    {
    }
}
