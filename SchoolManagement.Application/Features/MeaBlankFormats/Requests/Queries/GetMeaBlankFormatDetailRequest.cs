using MediatR;
using SchoolManagement.Application.DTOs.MeaBlankFormat;

namespace SchoolManagement.Application.Features.MeaBlankFormats.Requests.Queries
{
    public class GetMeaBlankFormatDetailRequest : IRequest<MeaBlankFormatDto>
    {
        public int MeaBlankFormatId { get; set; }
    }
}
