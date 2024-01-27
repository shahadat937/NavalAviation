using MediatR;

namespace SchoolManagement.Application.Features.ItemTypes.Requests.Commands
{
    public class DeleteItemTypeCommand : IRequest
    {
        public int ItemTypeId { get; set; }
    }
} 
