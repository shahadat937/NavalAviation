using SchoolManagement.Application.DTOs.Division;
using MediatR;

namespace SchoolManagement.Application.Features.Divisions.Requests.Queries
{
    public class GetDivisionDetailRequest : IRequest<DivisionDto>
    {
        public int DivisionId { get; set; }
    }
}
