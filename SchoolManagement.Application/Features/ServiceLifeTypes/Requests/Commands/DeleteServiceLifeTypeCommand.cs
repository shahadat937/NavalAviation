using MediatR;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands
{
    public class DeleteServiceLifeTypeCommand : IRequest
    {
        public int ServiceLifeTypeId { get; set; }
    }
} 
