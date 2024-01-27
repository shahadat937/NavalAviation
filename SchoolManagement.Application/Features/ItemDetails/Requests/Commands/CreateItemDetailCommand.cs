using MediatR;
using SchoolManagement.Application.DTOs.ItemDetail;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.ItemDetails.Requests.Commands
{
    public class CreateItemDetailCommand : IRequest<BaseCommandResponse>
    {
        public CreateItemDetailDto ItemDetailDto { get; set; }
    }
}
