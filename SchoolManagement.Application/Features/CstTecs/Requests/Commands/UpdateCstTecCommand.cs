using MediatR;
using SchoolManagement.Application.DTOs.CstTec;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Commands
{
    public class UpdateCstTecCommand : IRequest<Unit>
    { 
        public CstTecDto CstTecDto { get; set; }
    }
}
