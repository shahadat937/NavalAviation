using MediatR;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Commands
{
    public class DeleteItemInspectionCommand : IRequest
    {
        public int ItemInspectionId { get; set; }
    }
}
