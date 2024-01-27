using MediatR;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands
{
    public class DeleteEndLifeTypeCommand : IRequest
    {
        public int EndLifeTypeId { get; set; }
    }
} 
