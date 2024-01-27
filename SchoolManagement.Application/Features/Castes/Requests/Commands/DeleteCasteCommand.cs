using MediatR;

namespace SchoolManagement.Application.Features.Castes.Requests.Commands
{
    public class DeleteCasteCommand : IRequest
    {
        public int CasteId { get; set; }
    }
}
