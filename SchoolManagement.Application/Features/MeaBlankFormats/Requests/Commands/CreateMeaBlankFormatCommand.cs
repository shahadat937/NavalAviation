using MediatR;
using SchoolManagement.Application.DTOs.MeaBlankFormat;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands
{
    public class CreateMeaBlankFormatCommand : IRequest<BaseCommandResponse>
    {
        public CreateMeaBlankFormatDto MeaBlankFormatDto { get; set; }
    }
}
