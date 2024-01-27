using MediatR;
using SchoolManagement.Application.DTOs.Manufacture;

namespace SchoolManagement.Application.Features.Manufactures.Requests.Queries
{
    public class GetManufactureDetailRequest : IRequest<ManufactureDto>
    {
        public int ManufactureId { get; set; }
    }
}
