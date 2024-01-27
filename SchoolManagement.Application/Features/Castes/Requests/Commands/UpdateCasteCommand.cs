using SchoolManagement.Application.DTOs.Caste;
using MediatR;

namespace SchoolManagement.Application.Features.Castes.Requests.Commands
{
    public class UpdateCasteCommand : IRequest<Unit>
    {
        public CasteDto CasteDto { get; set; }

    }
}
