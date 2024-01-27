using MediatR;
using SchoolManagement.Application.DTOs.ItemInspection;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemInspections.Requests.Commands
{
    public class CreateItemInspectionCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemInspectionDto ItemInspectionDto { get; set; }
    }
}
