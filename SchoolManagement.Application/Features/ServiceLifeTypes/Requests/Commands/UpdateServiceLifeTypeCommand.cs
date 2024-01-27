using MediatR;
using SchoolManagement.Application.DTOs.ServiceLifeTypes;

namespace SchoolManagement.Application.Features.ServiceLifeTypes.Requests.Commands
{
    public class UpdateServiceLifeTypeCommand : IRequest<Unit>
    { 
        public ServiceLifeTypeDto ServiceLifeTypeDto { get; set; }
    }
}
