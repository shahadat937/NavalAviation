using MediatR;

namespace SchoolManagement.Application.Features.DegitalArchieveDocTypes.Requests.Commands
{
    public class DeleteDegitalArchieveDocTypeCommand : IRequest
    {
        public int DegitalArchieveDocTypeId { get; set; }
    }
}
