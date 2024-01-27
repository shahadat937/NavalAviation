using MediatR;
using SchoolManagement.Application.DTOs.CstTec;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.CstTecs.Requests.Commands
{
    public class CreateCstTecCommand : IRequest<BaseCommandResponse>
    {
        public CreateCstTecDto CstTecDto { get; set; }
    }
}
