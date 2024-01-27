using MediatR;
using SchoolManagement.Application.DTOs.EndLifeTypes;

namespace SchoolManagement.Application.Features.EndLifeTypes.Requests.Commands
{
    public class UpdateEndLifeTypeCommand : IRequest<Unit>
    { 
        public EndLifeTypeDto EndLifeTypeDto { get; set; }
    }
}
 