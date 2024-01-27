using SchoolManagement.Application.DTOs.Caste;
using MediatR;

namespace SchoolManagement.Application.Features.Castes.Requests.Queries
{
    public class GetCasteDetailRequest : IRequest<CasteDto>
    {
        public int CasteId { get; set; }
    }
}
