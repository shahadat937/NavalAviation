using MediatR;
using SchoolManagement.Application.DTOs.ItemStor;

namespace SchoolManagement.Application.Features.ItemStors.Requests.Commands
{
    public class UpdateItemStorCommand : IRequest<Unit>
    {
        public CreateItemStorDto UpdateItemStorDto { get; set; }
    }
}
