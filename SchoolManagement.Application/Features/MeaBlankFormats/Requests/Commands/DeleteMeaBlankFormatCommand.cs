using MediatR;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Commands
{
    public class DeleteMeaBlankFormatCommand : IRequest
    {
        public int MeaBlankFormatId { get; set; }
    }
}
