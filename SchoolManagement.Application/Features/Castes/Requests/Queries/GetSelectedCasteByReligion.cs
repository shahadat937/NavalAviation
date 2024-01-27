using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetSelectedCasteByReligion : IRequest<List<SelectedModel>>
    {
        public int ReligionId { get; set; } 
    }
}
