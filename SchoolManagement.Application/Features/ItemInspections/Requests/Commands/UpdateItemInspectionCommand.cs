using MediatR;
using SchoolManagement.Application.DTOs.ItemInspection;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Commands
{
    public class UpdateItemInspectionCommand : IRequest<Unit>
    {
        public ItemInspectionDto ItemInspectionDto { get; set; }
    }
}
