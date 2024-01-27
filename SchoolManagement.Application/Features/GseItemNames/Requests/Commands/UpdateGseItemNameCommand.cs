using MediatR;
using SchoolManagement.Application.DTOs.GseItemName;

namespace SchoolManagement.Application.Features.GseItemNames.Requests.Commands
{
    public class UpdateGseItemNameCommand : IRequest<Unit>
    {
        public GseItemNameDto GseItemNameDto { get; set; }
    }
}
